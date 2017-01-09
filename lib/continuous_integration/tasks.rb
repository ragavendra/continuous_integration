require_relative 'constants'

class DockerEndpoint < WEBrick::HTTPServlet::AbstractServlet

	def initialize param
		#def initialize(opts)   
		#super(opts)    
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
	def do_GET (request, response)

		#status, content_type, body = do_stuff_with request
		response.status = 200
		response['Content-Type'] = 'text/plain'
		response.body = 'Hello, World!'

		puts "this is a get request"
		#puts "Dir - #{root}"	
		#puts "Dir - #{File.expand_path '/home/raga/gitbase/test-auto/SOA/api/log/'}"	

		obj = {
			"TIME" => Time.now.strftime("%FT%T"),
			"foo" => "Test",
			"bar" => "QA-Automation",
			'a' => 2,
			'b' => 3.141,
			'COUNT' => 1,
			'c' => 'c',
			'd' => [ 1, "b", 3.14 ],
			'e' => { 'foo' => 'bar' },
			'g' => "Ragu's response",
			'h' => 1000.0,
			'i' => 0.001,
			'j' => "\xf0\xa0\x80\x81",
		}
		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"
	end

	def do_POST (request, response)

		requestHash = JSON.parse(request.body, symbolize_names: true)
		@repo_name = requestHash[:name]

		@git_branch = requestHash[:trigger_metadata][:ref]
		@git_branch = @git_branch.split('/')
		@git_branch = @git_branch.last

		#handle requests one at a time - Needs testing
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

	def docker_update
		Dir.chdir(DOCKER_PATH){
			#perform docker images update
			`sudo docker compose kill`
			`sudo docker compose rm`
			`sudo docker compose up -d`
		}

	end
	
	def run_api_tests
		Dir.chdir(API_SPECS_PATH){
			cmd = "RUBYOPT='-W0' HOST=#{HOST} RMQ_HOST=#{HOST} RMQ_VHOST=/ bundle exec rake cards:#{@git_branch} | aha --black >logs/#{@git_branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-API-run.htm"
			@result_api = %x[#{cmd}]
			#%x["bundle exec rake cards:dev | aha --black >$LOGPATH/$(date +\%d-\%m-\%Y-\%H-\%s)-run.htm"]
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


