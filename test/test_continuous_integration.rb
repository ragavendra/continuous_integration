require 'minitest/autorun'
require 'continuous_integration'

class HolaTest < Minitest::Test
	def test_run_ci
		#assert_equal "hello world", Hola.hi("english")
	end

	def test_shutdown_server
		#assert_equal "hello world", Hola.hi("ruby")
	end

	def test_run_server
		#assert_equal "hola mundo", Hola.hi("spanish")
	end
	
	def test_dir_mount
		#assert_equal "hola mundo", Hola.hi("spanish")
	end
end
