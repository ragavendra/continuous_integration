require_relative 'constants'

class DockerEndpoint < WEBrick::HTTPServlet::AbstractServlet

	def initialize param
		@resourcePath = "/cards"       
		@repo_name = ''
		@process_status = ''
		@result = ''
		@result_api = ''
		@result_ui = ''
		@git_branch = ''
		@lock = false
	end


	#curl localhost:8080/docker
	#POST call made by quay to CI server
	def do_POST (request, response)

		#parse JSOn to hash key
		requestHash = JSON.parse(request.body, symbolize_names: true)
		
		#fetch the github repo name
		@repo_name = requestHash[:name]

		#fetch the github branch name
		@git_branch = requestHash[:trigger_metadata][:ref]
		@git_branch = @git_branch.split('/')
		@git_branch = @git_branch.last

		#handle requests one at a time (to avoid concurrency) - Needs testing
		while @lock 
			@lock = true
			docker_update
			sleep 10

			run_api_tests
			run_ui_tests
			generate_log
			slack_post
			@lock = false
		end
	end	

	#update docker images locally
	def docker_update
		Dir.chdir(DOCKER_PATH){
			#perform docker images update
			`sudo docker compose kill`
			`sudo docker compose rm`
			`sudo docker compose up -d`
		}

	end
	
	#Action - run api tests
	def run_api_tests
		Dir.chdir(API_SPECS_PATH){
			#shell command to run my tests using rake . I am using `aha` shell tool to grab shell output to html
			cmd = "RUBYOPT='-W0' HOST=#{HOST} RMQ_HOST=#{HOST} RMQ_VHOST=/ bundle exec rake cars:#{@git_branch} | aha --black >logs/#{@git_branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-API-run.htm"
			@result_api = %x[#{cmd}] 
			# or use ` .... ` instead of %x[ .... ] to run commands
		}
	end
	
	def run_ui_tests
		Dir.chdir(UI_SPECS_PATH){
			#navigate to specs dir
			cmd = "HOST='https://#{HOST}' BROWSER=phantomjs SCREENS=true bundle exec rake selenium:#{@git_branch} | aha --black >logs/#{@git_branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-UI-run.htm"
			@result_ui = %x[#{cmd}]
		}	
	end

	def generate_log
		obj = {
			"Docker logs" => @process_status,
			"API logs" => @result_api,
			"SE logs" => @result_ui
		}
		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"
	end

	def slack_post
		#curl to post to slack for the team to see the results
	end
end

#Below is the POST from Quay.io, parse and use the necessary data
=begin

{
  "repository": "mynamespace/repository",
  "namespace": "mynamespace",
  "name": "repository",
  "docker_url": "quay.io/mynamespace/repository",
  "homepage": "https://quay.io/repository/mynamespace/repository/build?current=some-fake-build",
  "visibility": "public",

  "build_id": "build_uuid",
  "docker_tags": ["latest", "foo", "bar"],

  "trigger_kind": "github",                                       // Optional
  "trigger_id": "some-id-here",                                   // Optional
  "trigger_metadata": {                                           // Optional
    "default_branch": "master",
    "ref": "refs/heads/somebranch",
    "commit": "42d4a62c53350993ea41069e9f2cfdefb0df097d",
    "commit_info": {                                              // Optional
      "url": "http://path/to/the/commit",
      "message": "Some commit message",
      "date": 2395748365,
      "author": {                                                 // Optional
        "username": "fakeauthor",
        "url": "http://path/to/fake/author/in/scm",               // Optional
        "avatar_url": "http://www.gravatar.com/avatar/fakehash"   // Optional
      },
      "committer": {                                              // Optional
        "username": "fakecommitter",
        "url": "http://path/to/fake/comitter/in/scm",             // Optional
        "avatar_url": "http://www.gravatar.com/avatar/fakehash"   // Optional
      }
    }
  }
}

More info here -> http://docs.quay.io/guides/notifications.html#webhook_build_success

=end
