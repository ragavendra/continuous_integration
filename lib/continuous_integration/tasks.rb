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
		puts "this is a post request who received #{request.body}"

		requestHash = JSON.parse(request.body, symbolize_names: true)
		#repo_name = requestHash[:repository]
		#repo_name.split('/') repo_name[1]}
		@repo_name = requestHash[:name]
		#require 'pry'
		#binding.pry
=begin
		cmd ="docker logs --tail=9 #{@opts[:docker_compose_logger]}"
		ENV["http_proxy"] = ''
		Dir.chdir(@opts[:docker_compose_path]){
			@log_str = %x[#{cmd}]
		}
=end

		#%x["cd #{DOCKER_PATH}"]

=begin
		Dir.chdir(DOCKER_PATH){
			cmd = "git pull"
			@result = %x[#{cmd}]

			cmd = "sudo docker-compose pull #{@repo_name}"
			@result = %x[#{cmd}]

			cmd = "sudo docker-compose kill" #haproxy may need to be restarted
			#cmd = "sudo docker-compose kill #{@repo_name}"] #haproxy may need to be restarted
			@result = %x[#{cmd}]

			#%x[docker-compose rm -y]
			cmd = "sudo docker-compose up -d"
			@result = %x[#{cmd}]

			#%x["sudo docker-compose start #{@repo_name}""]
			cmd = "sudo docker-compose ps"
			@process_status = %x[#{cmd}]
			puts "Docker process status - #{@process_status}"
			#%x[docker-compose ps]
		}
=end
		@git_branch = requestHash[:trigger_metadata][:ref]
		#git_branch.split('/')"ref": "refs/heads/somebranch"
		@git_branch = @git_branch.split('/')
		@git_branch = @git_branch.last
		#navigate to specs dir
		#%x["cd #{API_SPECS_PATH}"]

		Dir.chdir(API_SPECS_PATH){
			cmd = "RUBYOPT='-W0' HOST=#{HOST} RMQ_HOST=#{HOST} RMQ_VHOST=/ bundle exec rake cards:#{@git_branch} | aha --black >logs/#{@git_branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-API-run.htm"
			@result_api = %x[#{cmd}]
			#%x["bundle exec rake cards:dev | aha --black >$LOGPATH/$(date +\%d-\%m-\%Y-\%H-\%s)-run.htm"]
		}


		#%x["cd #{UI_SPECS_PATH}"
		Dir.chdir(UI_SPECS_PATH){
			#navigate to specs dir
			cmd = "HOST='https://#{HOST}' BROWSER=phantomjs SCREENS=true bundle exec rake selenium:#{@git_branch} | aha --black >logs/#{@git_branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-UI-run.htm"
			@result_ui = %x[#{cmd}]
		}
		obj = {
			"Docker logs" => @process_status,
			"API logs" => @result_api,
			"SE logs" => @result_ui
		}
		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"

	end	

	#curl -d "{\"command\":\"ls\", \"par1\":\"/opt\"}" localhost:8080/docker/	
	def do_POST2 (request, response)
		puts "this is a post request who received #{request.body}"

		requestHash = JSON.parse(request.body, symbolize_names: true)
		#@opts[:confirmation_token] =  requestHash[:command]

		#cmd ="#{requestHash[:command]} docker logs --tail=9 #{@opts[:docker_compose_logger]}"
		cmd ="#{requestHash[:command]} #{requestHash[:par1]}"

		obj = {
			#"Result" => constants		response.body = JSON.generate obj
		#response['Content-Type'] = "application/json"
		}
	end	
end


