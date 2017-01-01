# continuous_integration

## Installation

Add this line to your application's Gemfile:

gem 'continuous_integration'

And then execute:

$ bundle

Or install it yourself as:

$ gem install continuous_integration

## Usage

Starting the server
```ruby
server = ContinuousIntegration.run_ci
```

Shutting it down
```ruby
ContinuousIntegration.shutdown_server server
```
