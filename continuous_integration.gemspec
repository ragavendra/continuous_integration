# frozen_string_literal: true

lib = File.expand_path('../lib', __FILE__)
$LOAD_PATH.unshift(lib) unless $LOAD_PATH.include?(lib)
require 'continuous_integration/version'

Gem::Specification.new do |gem|
  gem.name = 'continuous_integration'
  gem.version       = ContinuousIntegration::VERSION
  gem.authors       = ['Ragavendra Nagraj']
  gem.email         = ['ragavendra.bn@gmail.com']
  gem.description   = 'CI server for running integration tests using webrick'
  gem.summary       = 'One can run their UI and API tests using this gem'
  gem.homepage      = 'https://rubygems.org/gems/continuous_integration'
  gem.license       = 'MIT'

  # gem.files         = `git ls-files`.split($/)
  gem.files         = `git ls-files -z`.split("\x0").reject do |f|
    f.match(%r{^(test|spec|features)/})
  end
  # gem.executables   = gem.files.grep(%r{^bin/}).map{ |f| File.basename(f) }
  gem.bindir = 'bin'
  gem.executables   = ['continuous_integration']
  gem.test_files    = gem.files.grep(%r{^(test|spec|features)/})
  gem.require_paths = ['lib']

  gem.add_development_dependency 'minitest', '~> 5.0'
  gem.add_development_dependency 'rake', '~> 0'
end
