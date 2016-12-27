require 'webrick'
require 'json'
include WEBrick

#require 'views/error_view'
require_relative 'constants'
require_relative 'tasks'

#path for the web server to serve the test results
root = File.expand_path "#{API_SPECS_PATH}/logs" 

server = WEBrick::HTTPServer.new :Port => 8080, :DocumentRoot => root, :DirectoryIndex  => []

server.mount "/qa/docker/", DockerEndpoint

trap("INT") {
	server.shutdown
}

