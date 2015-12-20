require 'webrick'
require 'json'
include WEBrick

DOCKER_PATH = "#{ENV['HOME']}/github/devops/soa/dev"
API_SPECS_PATH = "#{ENV['HOME']}/github/tests/soa/api"
UI_SPECS_PATH = "#{ENV['HOME']}/github/tests/soa/se"
#SPECS_LOGPATH = "#{SPECS_PATH}/logs/#{@repo_name}"
RAKE_TASK = "cards:dev"
#; cd $HOME/gitbase/test-auto/SOA/api; bundle exec rake cards:dev | aha --black >$LOGPATH"

=begin
apiUser.rb
attr_accessor :autoBankVerificationService
attr_accessor :responseAssertions
attr_accessor :memberService
    
    def initialize(opts)
	@opts = opts
	@memberService = MemberService.new(@opts)
	@responseAssertions = ResponseAssertions.new(@opts)

specs.rb
@apiUser = ApiUser.new(@opts)   
        #puts @opts.inspect             
		    
	#signup, activate, login and credit application
	res = @apiUser.memberService.signup 

=end
class DockerEndpoint < WEBrick::HTTPServlet::AbstractServlet

	def initialize   
		#def initialize(opts)   
		#super(opts)    
		@resourcePath = "/cards"       
		@repo_name = ''
		@process_status = ''
		@git_branch = ''
	end
#DOCKER_PATH_1_ = '/home/uname/github/devops/soa/dev/'
#can be called outside class like DockerEndPoint::DOCKER_PATH_1

	#curl localhost:8080/docker
	def do_GET (request, response)
		
		#status, content_type, body = do_stuff_with request
		response.status = 200
		response['Content-Type'] = 'text/plain'
		response.body = 'Hello, World!'
		
		puts "this is a get request"
		#puts "Dir - #{root}"	
		#puts "Dir - #{File.expand_path '/home/ragavendran@mogo.ca/gitbase/test-auto/SOA/api/log/'}"	
		
		obj = {
			"TIME" => Time.now.strftime("%FT%T"),
			"foo" => "Test",
			"bar" => "QA-Automation",
			'a' => 2,
			'b' => 3.141,
			'COUNT' => 1,
			'c' => 'c',
			'd' => [ 1, "b", 3.14 ],
			'e' => { 'foo' => 'bar' },
			'g' => "Ragu's response",
			'h' => 1000.0,
			'i' => 0.001,
			'j' => "\xf0\xa0\x80\x81",
		}
		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"
	end

=begin uncomment if conf token is not in response. This code parses confirmation token from response
		cmd ="docker logs --tail=9 #{@opts[:docker_compose_logger]}"
		ENV["http_proxy"] = ''
		Dir.chdir(@opts[:docker_compose_path]){
			@log_str = %x[#{cmd}]
		}

		puts "Verify pin pos: " + @log_str.index("verification_pin").to_s unless @log_str.index("verification_pin")

		if @log_str.index("confirmation_token")
			str_pos =  @log_str.index("confirmation_token")
			@opts[:user_confirmation_token] = @log_str[(str_pos + 21), 36]
		end
		ENV["http_proxy"] = 'http://localhost:8888'
=end

=begin
		{
			"repository": "mynamespace/repository",
			"namespace": "mynamespace",
			"name": "repository",
			"docker_url": "quay.io/mynamespace/repository",
			"homepage": "https://quay.io/repository/mynamespace/repository/build?current=some-fake-build",
			"visibility": "public",

			"build_id": "build_uuid",
			"build_name": "some-fake-build",
			"docker_tags": ["latest", "foo", "bar"],

			"trigger_kind": "github",                                       #// Optional
			"trigger_id": "some-id-here",                                   #// Optional
			"trigger_metadata": {                                           #// Optional
				"default_branch": "master",
				"ref": "refs/heads/somebranch",
				"commit": "42d4a62c53350993ea41069e9f2cfdefb0df097d",
				"commit_info": {                                              #// Optional
					"url": "http://path/to/the/commit",
					"message": "Some commit message",
					"date": 2395748365,
					"author": {                                             #    // Optional
						"username": "fakeauthor",
						"url": "http://path/to/fake/author/in/scm",               #// Optional
						"avatar_url": "http://www.gravatar.com/avatar/fakehash"   #// Optional
					},
					"committer": {                                           #   // Optional
						"username": "fakecommitter",
						"url": "http://path/to/fake/comitter/in/scm",        #     // Optional
						"avatar_url": "http://www.gravatar.com/avatar/fakehash"   #// Optional
					}
				}
			}
		}
=end

	#curl -d "{\"command\":\"ls\", \"par1\":\"/opt\"}" localhost:8080/docker/	
	def do_POST1 (request, response)
		puts "this is a post request who received #{request.body}"
		#repo_name = requestHash[:repository]
		#repo_name.split('/') repo_name[1]}
 		@repo_name = requestHash[:name]
		%x["cd #{DOCKER_PATH}"]
		%x["git pull"]
		%x["docker-compose pull"]
		%x["docker-compose pull #{@repo_name}"]
		%x["docker-compose kill"]
		%x["docker-compose kill #{@repo_name}"]
		#%x[docker-compose rm -y]
		%x["docker-compose up -d"]
		%x["docker-compose start #{@repo_name}""]
		@process_status = %x["docker-compose ps"]
		puts "Docker process status - #{@process_status}"
		

		#%x[docker-compose ps]
		
 		@git_branch = requestHash[:trigger_metadata][:ref]
		#git_branch.split('/')"ref": "refs/heads/somebranch"
		@git_branch = @git_branch[2]

		#navigate to specs dir
		%x["cd #{API_SPECS_PATH}"]
		%x["bundle exec rake #{@repo_name}:#{@git_branch} | aha --black >logs/#{@git-branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-API-run.htm"]
		#%x["bundle exec rake cards:dev | aha --black >$LOGPATH/$(date +\%d-\%m-\%Y-\%H-\%s)-run.htm"]
		
		#navigate to specs dir
		%x["cd #{UI_SPECS_PATH}"]
		%x["bundle exec rake #{@repo_name}:#{@git_branch} | aha --black >logs/#{@git-branch}/$(date +\%d-\%m-\%Y-\%H-\%s)-UI-run.htm"]
		
		#requestHash = JSON.parse(request.body, symbolize_names: true)
		#@opts[:confirmation_token] =  requestHash[:command]
		#"repository": "mynamespace/repository"
=begin	
		##################<SOA - Cards>#################
		LOGDIR=card-team

		#perform git pull
		00 17,23,5,11 * * * cd $HOME/gitbase/devops/services/soa/dev; git pull; cd $SPECS_PATH; git pull 2>/tmp/git-pull.log
		#00 17,23,5,11 * * * cd $DOCKER_PATH; git config --global credential.helper 'cache --timeout 21600'; git pull; cd $SPECS_PATH; git pull 2>/tmp/git-pull.log

		#run cards
		00 17 * * 1-5 export LOGPATH=$HOME/gitbase/test-auto/SOA/api/logs/$LOGDIR/$(date +\%d-\%m-\%Y-\%H-\%s)-run.htm; cd $HOME/gitbase/test-auto/SOA/api; bundle exec rake cards:dev | aha --black >$LOGPATH
		#; bin/slack.sh 2>/tmp/specs-run.log
		#00 17,21 * * 1-5 cd $HOME/gitbase/test-auto/SOA/api; bin/docker.sh; sleep 15; bundle exec rake cards:all | aha --black >logs/SOACards/$(date +\%d-\%m-\%Y-\%H)-run.htm
		################</SOA - Cards>################
=end
		obj = {
			"Result" => @process_status
		}
		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"

	end	

	#curl -d "{\"command\":\"ls\", \"par1\":\"/opt\"}" localhost:8080/docker/	
	def do_POST (request, response)
		puts "this is a post request who received #{request.body}"
			
		requestHash = JSON.parse(request.body, symbolize_names: true)
		#@opts[:confirmation_token] =  requestHash[:command]
		
		#cmd ="#{requestHash[:command]} docker logs --tail=9 #{@opts[:docker_compose_logger]}"
		cmd ="#{requestHash[:command]} #{requestHash[:par1]}"
		
		obj = {
			"Result" => %x[#{cmd}]
		}

		response.body = JSON.generate obj
		response['Content-Type'] = "application/json"

	end	
#parse the response JSON here

		#res = @apiUser.memberService.signup
		#assert res.code == 200, "Invalid response code #{res}, should be 200-OK"
#=begin
		#resHash = JSON.parse(res.body, symbolize_names: true)
		#@opts[:confirmation_token] =  resHash[:confirmation_token]

end

#root = File.expand_path '~/gitbase/test-auto/SOA/api/log/'
root = File.expand_path '/home/ragu/Documents/github/SOA/webrick/www'

#server = WEBrick::HTTPServer.new(:Port => 3030)
server = WEBrick::HTTPServer.new :Port => 8080, :DocumentRoot => root, :DirectoryIndex  => []

server.mount "/docker", DockerEndpoint

trap("INT") {
	server.shutdown
}

server.start

=begin boot.rb
# boot.rb is the service initialization file.
# Its responsibilities include configuring the logger, setting up paths,
# schemas, templates, etc. and providing access to these under a global
# `App` object.
# boot.rb gets required by main.rb where main.rb is responsible for providing
# an interface to actually run the service.
#
$:.unshift File.dirname(__FILE__)
$:.unshift File.join(File.dirname(__FILE__), 'app')

require 'rubygems'
require 'bundler/setup'
require 'active_support/core_ext/hash/indifferent_access'

App = Struct.new(:root, :env, :schema_dir, :settings, :logger, :db, :session, :name).new

App.root = File.dirname(__FILE__)
App.env = ENV['SERVICE_ENV'] || 'dev'
App.schema_dir = File.join(App.root, 'schemas')
App.name = ENV['APP_NAME']
App.session = {}

require 'erb'
require 'yaml'
App.define_singleton_method(:load_erb_yaml) do |relative_path|
  path = File.join(App.root, relative_path)
  file = File.read(path)
  erb = ERB.new(file).result
  YAML.load(erb)
end

App.settings = HashWithIndifferentAccess.new(App.load_erb_yaml('config/settings.yaml'))

#-- Logger Configuration -------------------------------------------------------------------------------------
require 'logger'
App.logger = Logger.new(STDOUT)
App.logger.level = App.settings[:logger][:level]
App.logger.progname = App.settings[:logger][:name]

#-- DB Configuration -----------------------------------------------------------------------------------------
db_config = App.load_erb_yaml('config/database.yaml')[App.env]

require 'sequel'
db_url = <<-DB_URL
#{db_config['adapter']}://#{db_config['host']}:#{db_config['port']}/#{db_config['database']}?\
encoding=#{db_config['encoding']}&\
pool=#{db_config['pool']}&\
username=#{db_config['username']}&\
password=#{db_config['password']}
DB_URL

App.db = Sequel.connect(db_url)
App.db.tables # fails with Sequel::DatabaseConnectionError if connection cannot be established

#-- Debug Configuration --------------------------------------------------------------------------------------
if App.env == 'test' || App.env == 'dev'
  require 'byebug'
  App.db.loggers << App.logger
end

###########	<publish.rb 

require 'json'
require 'active_support/core_ext/string/filters' # String#squish

#-- Custom Errors --------------------------------------------------------------------------------------------
class MessageHasNoBodyError < StandardError; end
class MessageHasNoHeadersError < StandardError; end
class MessageHasNoTypeError < StandardError; end
class MessageHasNoRoutingKeyError < StandardError; end


#-- Publish Interface ----------------------------------------------------------------------------------------
module Publish
  extend self

  def call(channel, correlation_id, response)
    fail MessageHasNoBodyError.new       unless response.respond_to?(:body)
    fail MessageHasNoHeadersError.new    unless response.respond_to?(:headers)
    fail MessageHasNoTypeError.new       unless response.respond_to?(:type)
    fail MessageHasNoRoutingKeyError.new unless response.respond_to?(:routing_key)

    exchange = channel.fanout(App.settings[:bus][:exchange], durable: true)
    options = publish_settings(correlation_id, response)

    App.logger.debug("#{correlation_id} Publishing message: routing_key: '#{options[:routing_key]}'")
    App.logger.debug("#{correlation_id} Publishing message: type:....... '#{options[:type]}'")
    App.logger.debug("#{correlation_id} Publishing message: headers:.... '#{options[:headers]}'")
    App.logger.debug("#{correlation_id} Publishing message: body:....... '#{response.to_json.squish}'")

    exchange.publish(response.body.to_json, options)
  end

  private

    def publish_settings(correlation_id, response)
      {
        routing_key: response.routing_key || App.settings[:bus][:routing_key],
        type: response.type,
        content_type: 'application/json',
        correlation_id: correlation_id,
        headers: response.headers
      }
    end

end

############### router.rb #################
require 'json-schema'
require 'date' # future_or_present_date_validator

Dir["app/controllers/**/*.rb"].each { |file| require file }

#-- Errors ---------------------------------------------------------------------------------------------------
class JsonSchemaNotFoundError < StandardError; end

class SoaServiceError < StandardError
  attr_reader :errors
  def initialize(errors)
    @errors = errors
  end
end

class JsonValidationError < StandardError
  attr_accessor :errors
  def initialize(errors)
    @errors = errors
  end
end

#-- Router Interface -----------------------------------------------------------------------------------------
class Router
  ROUTES_PATH='config/routes.cfg'

  def initialize
    @routes = {}
    @schemas = {}
    File.foreach(File.join(App.root, ROUTES_PATH)) do |line|
      next if line.match(/^\s*#/) || line.match(/\A\s*\Z/)
      cfg = eval("{ #{line} }")
      schema = cfg.delete(:schema)
      @routes.merge!(cfg) { |key, old, new| Array(old) | Array(new) }
      @schemas.merge!(cfg.keys.first => schema)
    end
  end

  def call(routing_key, type, body, params)
    domain = routing_key.split('.').first
    key = routing_key.gsub(/\./, '_')
    method = "#{key}_#{type}".to_sym

    return unhandled unless @routes.has_key?(method)

    fail SoaServiceError.new(HashWithIndifferentAccess.new(JSON.parse(body))) if soa_service_error?(params, :header)
    parsed_body = HashWithIndifferentAccess.new(JSON.parse(body))
    fail SoaServiceError.new(HashWithIndifferentAccess.new(JSON.parse(body))) if soa_service_error?(parsed_body, :body)

    response = []

    Array(@routes[method]).each_with_index do |controller_action, index|
      controller, action = @routes[method].split('.')
      controller = controller.constantize

      return unhandled unless controller.respond_to?(action)

      if @schemas[method]
        schema = @schemas[method].kind_of?(Array) ? (@schemas[method][index] || @schemas[method].last) : @schemas[method]
      else
        schema = "#{domain}/#{type}-schema"
      end
      fail_unless_schema_match!(body, "#{schema}.json")

      response << controller.send(action, parsed_body, params)
    end

    response.flatten(1)
  end

  private

    # type = [:header, :body] # -> One of these.
    def soa_service_error?(hash, type)
      case type
      when :header
        hash.has_key?(:success) && hash[:success] == false ||
          hash.has_key?('success') && hash['success'] == false
      when :body
        hash.has_key?(:errors) || hash.has_key?('errors')
      else
        false
      end
    end

    def unhandled
      App.logger.info("Skipping unhandled message")
      nil
    end

    def future_or_present_date_validator(value)
      date = Date.parse(value)
      fail JSON::Schema::CustomFormatError.new("Date must not be before today") if date < Date.today
    rescue => e
      raise JSON::Schema::CustomFormatError.new(e.message)
    end

    def fail_unless_schema_match!(body, schema_file)
      schema_file = File.join(App.schema_dir, schema_file)
      fail JsonSchemaNotFoundError.new(schema_file) unless File.exists?(schema_file)

      JSON::Validator.register_format_validator(
        'future-or-present-date',
        method(:future_or_present_date_validator),
        ['draft4'])

      errors = JSON::Validator.fully_validate(schema_file, body, errors_as_objects: true)
      fail JsonValidationError.new(errors) if errors.any?
    end

end

# main.rb is responsible for providing an interface to actually run the service.
# See boot.rb for configuration and environment setup.
#
require_relative 'boot'

require 'rmq_foundation'
require 'json'
require 'active_support/core_ext/object/blank'
require 'active_support/core_ext/string/filters' # String#squish
require 'active_support/core_ext/hash/indifferent_access'

require_relative 'publish'
require_relative 'router'
require 'views/error_view'
require 'views/soa_service_error_view'


#-- Errors ---------------------------------------------------------------------------------------------------
class MissingCorrelationIdError < StandardError; end

class MissingAMQPExchangeError  < StandardError
  def initialize(exchange)
    super("Exchange '#{exchange}' doesn't exist!")
  end
end

#-- Helpers --------------------------------------------------------------------------------------------------
module Main
  def self.create_rmq_publish_channel(rmq_client)
    rmq_connection = rmq_client.connection

    App.logger.info("Creating publish channel")
    rmq_channel = rmq_connection.create_channel

    App.logger.info("Connecting to exchange: '#{App.settings[:bus][:exchange]}'")

    if !rmq_connection.exchange_exists?(App.settings[:bus][:exchange])
      fail MissingAMQPExchangeError.new(App.settings[:bus][:exchange])
    end

    rmq_channel
  end

  # NOTE: This function should be removed in proper clients.
  # All this does is create the queue to read from.  Proper clients should have the RabbitMQ
  # definitions file updated properly to support them.
  # :nocov:
  def self.sample_setup # TODO: Remove this method in new service
    require 'bunny'
    conn = Bunny.new(host: App.settings[:bus][:host])
    conn.start
    ch = conn.create_channel

    x_sample  = Bunny::Exchange.new(ch, :topic, "sample", auto_delete: false, durable: true)
    x_sample.bind("routing", routing_key: "sample.#")

    q = ch.queue("sample", auto_delete: false, durable: true)
    q.bind("sample", routing_key: "sample.perform", auto_delete: false, durable: true)

    x_sample_event = Bunny::Exchange.new(ch, :fanout, "sample.event", auto_delete: false, durable: true)
    x_sample_event.bind("sample", routing_key: "sample.event", auto_delete: false, durable: true)

    q.bind("sample.event")

    conn.close
  end
  # :nocov:
end

#-- Entrypoint -----------------------------------------------------------------------------------------------
def run
  Main.sample_setup # TODO: Remove this call in new service

  App.logger.info("Attempting to connect to #{App.settings[:bus][:host]}")
  client = RmqFoundation::Client.new(App.settings[:message_bus])

  router = Router.new
  publish_channel = Main.create_rmq_publish_channel(client)

  App.logger.info("Launching worker")
  client.async_subscribe(App.settings[:bus][:queue], block: true, manual_ack: true) do |delivery_info, properties, body|
    type = properties.type
    App.session[:correlation_id] = correlation_id = properties.correlation_id
    App.logger.debug("#{correlation_id} Message received: routing_key: '#{delivery_info.routing_key}'")
    App.logger.debug("#{correlation_id} Message received: type:....... '#{type}'")
    App.logger.debug("#{correlation_id} Message received: headers:.... '#{properties.headers}'")
    App.logger.debug("#{correlation_id} Message received: body:....... '#{body.to_s.squish}'")

    begin
      fail MissingCorrelationIdError.new unless correlation_id.present?

      params = HashWithIndifferentAccess.new(properties.to_hash.merge(properties[:headers] || {}).keep_if { |k,_| k != :headers })

      response = router.call(delivery_info.routing_key, type, body, params)
      publish = -> (msg) { Publish.call(publish_channel, correlation_id, msg) if msg.is_a?(Views::BaseView) }
      Array(response).each { |response| publish.call(response) }

    rescue SoaServiceError => e
      response = Views::SoaServiceErrorView.new(e.errors, delivery_info.routing_key)
      Publish.call(publish_channel, correlation_id, response)

    rescue JsonValidationError => e
      response = Views::JsonSchemaErrorView.new(e.errors, type)
      Publish.call(publish_channel, correlation_id, response)

    rescue => e
      App.logger.error(e)
      response = Views::ErrorView.new(e, type)
      Publish.call(publish_channel, correlation_id, response)

    ensure
      client.channel.acknowledge(delivery_info.delivery_tag, false)
    end
  end

rescue => e
  App.logger.error(e)

  if client.connection.respond_to?(:connected?) && client.connection.connected?
    client.send(:close_connection)
  end
end

=end


