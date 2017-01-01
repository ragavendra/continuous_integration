# -*- encoding: utf-8 -*-
lib = File.expand_path('../lib', __FILE__)
$LOAD_PATH.unshift(lib) unless $LOAD_PATH.include?(lib)
require 'continuous_integration/version'

Gem::Specification.new do |gem|
	gem.name          = "continuous_integration"
	gem.version       = ContinuousIntegration::VERSION
	gem.authors       = ["Ragavendra Nagraj"]
	gem.email         = ["ragavendra.bn@gmail.com"]
	gem.description   = %q{CI server for running integration tests using webrick}
	gem.summary       = %q{One can run their UI and API tests using this gem}
	gem.homepage      = ""

	gem.files         = `git ls-files`.split($/)
	gem.executables   = gem.files.grep(%r{^bin/}).map{ |f| File.basename(f) }
	gem.test_files    = gem.files.grep(%r{^(test|spec|features)/})
	gem.require_paths = ["lib"]

	gem.add_development_dependency 'rspec', '~> 2.7'
	gem.add_development_dependency 'rake'
end
