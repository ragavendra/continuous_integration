require 'webrick'
require 'json'
include WEBrick

require 'continuous_integration/constants'
require 'continuous_integration/tasks'
require 'continuous_integration/version'

module ContinuousIntegration

	def self.run_ci
		#path for the web server to serve the test results
		root = File.expand_path "#{API_SPECS_PATH}/logs" 
		
		#run the server
		server = run_server root

		#mount the dir
		dir_mount server
		
		#shut server down on any interrupt
		trap("INT") {
			shutdown_server server
		}

		return server
	end

	def self.shutdown_server server
		server.shutdown
	end
	
	private

	def self.run_server root
		WEBrick::HTTPServer.new :Port => PORT_NUM, :DocumentRoot => root, :DirectoryIndex  => []
	end
	
	def self.dir_mount server
		server.mount SUB_URI, DockerEndpoint
	end


end
