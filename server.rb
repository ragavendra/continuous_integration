require 'webrick'
require 'json'
include WEBrick

DOCKER_PATH = '/home/uname/github/devops/soa/dev/'
class DockerEndpoint < WEBrick::HTTPServlet::AbstractServlet
	#curl localhost:8080/docker
	def do_GET (request, response)
		
		#status, content_type, body = do_stuff_with request
		response.status = 200
		response['Content-Type'] = 'text/plain'
		response.body = 'Hello, World!'
		
		puts "this is a get request"
		#puts "Dir - #{root}"	
		#puts "Dir - #{File.expand_path '/home/ragavendran@mogo.ca/gitbase/test-auto/SOA/api/log/'}"	
		
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

=begin uncomment if conf token is not in response. This code parses confirmation token from response
		cmd ="docker logs --tail=9 #{@opts[:docker_compose_logger]}"
		ENV["http_proxy"] = ''
		Dir.chdir(@opts[:docker_compose_path]){
			@log_str = %x[#{cmd}]
		}

		puts "Verify pin pos: " + @log_str.index("verification_pin").to_s unless @log_str.index("verification_pin")

		if @log_str.index("confirmation_token")
			str_pos =  @log_str.index("confirmation_token")
			@opts[:user_confirmation_token] = @log_str[(str_pos + 21), 36]
		end
		ENV["http_proxy"] = 'http://localhost:8888'
=end

=begin
		{
			"repository": "mynamespace/repository",
			"namespace": "mynamespace",
			"name": "repository",
			"docker_url": "quay.io/mynamespace/repository",
			"homepage": "https://quay.io/repository/mynamespace/repository/build?current=some-fake-build",
			"visibility": "public",

			"build_id": "build_uuid",
			"build_name": "some-fake-build",
			"docker_tags": ["latest", "foo", "bar"],

			"trigger_kind": "github",                                       #// Optional
			"trigger_id": "some-id-here",                                   #// Optional
			"trigger_metadata": {                                           #// Optional
				"default_branch": "master",
				"ref": "refs/heads/somebranch",
				"commit": "42d4a62c53350993ea41069e9f2cfdefb0df097d",
				"commit_info": {                                              #// Optional
					"url": "http://path/to/the/commit",
					"message": "Some commit message",
					"date": 2395748365,
					"author": {                                             #    // Optional
						"username": "fakeauthor",
						"url": "http://path/to/fake/author/in/scm",               #// Optional
						"avatar_url": "http://www.gravatar.com/avatar/fakehash"   #// Optional
					},
					"committer": {                                           #   // Optional
						"username": "fakecommitter",
						"url": "http://path/to/fake/comitter/in/scm",        #     // Optional
						"avatar_url": "http://www.gravatar.com/avatar/fakehash"   #// Optional
					}
				}
			}
		}
=end

	#curl -d "{\"command\":\"ls\", \"par1\":\"/opt\"}" localhost:8080/docker/	
	def do_POST1 (request, response)
		puts "this is a post request who received #{request.body}"
		repo_name = requestHash[:repository]
		repo_name.split('/')

		%x["cd #{DOCKER_PATH}"]
		%x["docker-compose pull"]
		%x["docker-compose pull #{repo_name[1]}"]
		%x["docker-compose kill"]
		%x["docker-compose kill #{repo_name[1]}"]
		#%x[docker-compose rm -y]
		%x["docker-compose up -d"]
		%x["docker-compose start #{repo_name[1]}""]
		#%x[docker-compose ps]
		requestHash = JSON.parse(request.body, symbolize_names: true)
		#@opts[:confirmation_token] =  requestHash[:command]
		#"repository": "mynamespace/repository"
		
		process_status = %x["docker-compose ps"]
		puts "Docker process status - #{process_status}"
		obj = {
			"Result" => process_status
		}

		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"

	end	

	#curl -d "{\"command\":\"ls\", \"par1\":\"/opt\"}" localhost:8080/docker/	
	def do_POST (request, response)
		puts "this is a post request who received #{request.body}"
			
		requestHash = JSON.parse(request.body, symbolize_names: true)
		#@opts[:confirmation_token] =  requestHash[:command]
		
		#cmd ="#{requestHash[:command]} docker logs --tail=9 #{@opts[:docker_compose_logger]}"
		cmd ="#{requestHash[:command]} #{requestHash[:par1]}"
		
		obj = {
			"Result" => %x[#{cmd}]
		}

		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"

	end	
#parse the response JSON here

		#res = @apiUser.memberService.signup
		#assert res.code == 200, "Invalid response code #{res}, should be 200-OK"
#=begin
		#resHash = JSON.parse(res.body, symbolize_names: true)
		#@opts[:confirmation_token] =  resHash[:confirmation_token]

end

#root = File.expand_path '~/gitbase/test-auto/SOA/api/log/'
root = File.expand_path '/home/ragu/Documents/github/SOA/webrick/www'

#server = WEBrick::HTTPServer.new(:Port => 3030)
server = WEBrick::HTTPServer.new :Port => 8080, :DocumentRoot => root, :DirectoryIndex  => []

server.mount "/docker", DockerEndpoint

trap("INT") {
	server.shutdown
}

server.start
