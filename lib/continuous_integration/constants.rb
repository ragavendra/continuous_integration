#this file is like the global variable file

DOCKER_PATH = "#{ENV['HOME']}/repos/devops/services/soa/dev"
API_SPECS_PATH = "#{ENV['HOME']}/repos/api_tests"
UI_SPECS_PATH = "#{ENV['HOME']}/repos/selenium_tests"

HOST = "dockervm"
#HOST="https://amzn-se001"
#HOST="https://qa.hostname.ca"
BROWSER = "phantomjs"
SCREENS = true

PORT_NUM = 8080
SUB_URI = "/qa/docker/"
