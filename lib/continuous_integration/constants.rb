# frozen_string_literal: true

# this file is like the global variable file

# path to your docker compose file ( many services here )
DOCKER_PATH = "#{ENV['HOME']}/repos/devops/services/soa/dev"

# path to your integration API tests
API_SPECS_PATH = "#{ENV['HOME']}/repos/api_tests"

# path to your UI or selenium tests
UI_SPECS_PATH = "#{ENV['HOME']}/repos/ui_tests"

HOST = 'dockervm'
# HOST="https://amzn-se001"
# HOST="https://qa.hostname.ca"
BROWSER = 'phantomjs'
SCREENS = true

PORT_NUM = 8080
SUB_URI = '/qa/docker/'
