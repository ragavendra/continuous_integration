require 'webrick'
require 'json'
include WEBrick

require 'continuous_integration/constants'
require 'continuous_integration/tasks'
require 'continuous_integration/version'

module ContinuousIntegration

	#setup the CI server config
	def self.setup_server
		#path for the web server to serve the test results
		root = File.expand_path "#{API_SPECS_PATH}/logs" 
		
		#create the server
		server = create_server root

		#mount the dir
		dir_mount server
		
		#shut server down on any interrupt
		trap("INT") {
			shutdown_server server
		}

		return server
	end
	
	def self.start_server server
		server.start
	end
	
	def self.shutdown_server server
		dir_unmount server 
		server.shutdown
	end

	private

	def self.create_server root
		WEBrick::HTTPServer.new :Port => PORT_NUM, :DocumentRoot => root, :DirectoryIndex  => []
	end
	
	def self.dir_mount server
		server.mount SUB_URI, DockerEndpoint
	end

	def self.dir_unmount server
		server.unmount SUB_URI
	end
end
