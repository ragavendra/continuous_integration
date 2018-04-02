# frozen_string_literal: true

require 'webrick'
require 'json'

require_relative 'constants'
require_relative 'tasks'
require_relative 'version'

# Module to perform CI operations!
module ContinuousIntegration
	# class to perform the server operations
	class Server
		# Perform Continuous Integration operations!
		#
		# Example:
		#   >> server = ContinuousIntegration.setup_server
		#   >> ContinuousIntegration.start_server server
		#   => INFO  WEBrick x.x.x
		#
		# Arguments:
		#   server: (Object)

		attr_accessor	:server, :root

		def self.start_server
			self.setup_server
			@server.start
		end

		# setup the CI server config
		def self.setup_server
			# path for the web server to serve the test results
			@root = File.expand_path "#{API_SPECS_PATH}/logs"

			# create the server
			@server = self.create_server

			# mount the dir
			dir_mount

			# shut server down on any interrupt
			trap('INT') do
				shutdown_server
			end
		end

		def self.shutdown_server
			dir_unmount
			@server.shutdown
		end

		private_class_method

		def self.create_server
			WEBrick::HTTPServer.new(
				Port: PORT_NUM,
				DocumentRoot: @root,
				DirectoryIndex: []
			)
		end

		def self.dir_mount
			@server.mount SUB_URI, DockerEndpoint
		end

		def self.dir_unmount
			@server.unmount SUB_URI
		end
	end
end
