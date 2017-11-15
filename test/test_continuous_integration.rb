require 'minitest/autorun'
require 'continuous_integration'

class ContinuousIntegrationTest < Minitest::Test
	def setup
		#@server = ContinuousIntegration.setup_server
		@root = File.expand_path "#{API_SPECS_PATH}/logs" 
		@t1 = nil
		@t2 = nil
		@server = nil
	end

	def teardown
	end

	def test_order
		:alpha
	end
	
	def test_server_operations
		until @t1.nil? do
			@t1.join
		end
		@server = ContinuousIntegration.setup_server if (@t1.nil? && @server.nil?) 
		assert_kind_of WEBrick::HTTPServer, @server, "Shutdown server did not return object"

		@t1 = Thread.new { @server = ContinuousIntegration.start_server @server }
		assert_kind_of WEBrick::HTTPServer, @server, "Shutdown server did not return object #{@server}"

		@t2 = Thread.new { @server = ContinuousIntegration.shutdown_server @server }
		@t2.join
		assert_nil @server, "Server class is not nil"
		assert @t1.status, "Thread is still running #{@t1.status}"
	end
end
