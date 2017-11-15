require 'minitest/autorun'
require 'continuous_integration'

class ContinuousIntegrationTest < Minitest::Test
	def setup
		#@server = ContinuousIntegration.setup_server
		@root = File.expand_path "#{API_SPECS_PATH}/logs" 
	end

	def teardown
		@server = nil
	end

	def test_order
		:alpha
	end
	
	def test_setup_server
		#@server = ContinuousIntegration.setup_server
#		assert_kind_of WEBrick::HTTPServer, @server, "Shutdown server did not return object"
#		@server = ContinuousIntegration.shutdown_server @server
		#assert_equal "hello world", Hola.hi("english")
		#@server = ContinuousIntegration.dir_unmount @root
	end
	
	def test_shutdown_server
		@server = ContinuousIntegration.setup_server
		t1 = Thread.new { @server = ContinuousIntegration.start_server @server }
		assert_kind_of WEBrick::HTTPServer, @server, "Shutdown server did not return object"
		@server = ContinuousIntegration.shutdown_server @server
		assert_nil @server, "Server class is not nil"
		assert t1.status, "Thread is still running"
	end
=begin	
	def test_start_server
		#@server = ContinuousIntegration.start_server @server
		assert_empty !@server, "Start server did not return object"
		ContinuousIntegration.shutdown_server @server
	end

	def test_create_server
		@server = ContinuousIntegration.create_server @root
		assert_empty !@server, "Create server did not return object"
	end
	
	def test_dir_mount
		@server = ContinuousIntegration.create_server @root
		@server = ContinuousIntegration.dir_mount @server
		assert_empty !@server, "Create server did not return object"
	end	
=end
end
