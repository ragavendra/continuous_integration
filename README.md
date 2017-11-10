# ContinuousIntegration: a gem to say consume the Quay.io posts on sucessful build completion and perform the docker operations and tests run or say perform the CI capability 

ContinuousIntegration helps to perform CI capability in the minimalistic approach.

Lets say a developer checks in the code to the github. The container repository like Quay receives a call to perform the operations on building the new say Docker repo and host it. Quay can be later configured to be able to shoot out a POST call when this is done. Such call is consumed by the continuous_integration to be able to perform customized operations. Like say, destroy the local or old docker container(s). Pull the latest container(s) from the Quay. Pull the latest API or UI tests and run them against the new container(s). Finally report the test run results to the team on Slack or wherever.


### History

The idea came into picture when trying to leverage the right CI tool to help run the automated API or the UI tests. Having traversed the various industry standard CIs it was thought to anyway have a light weight CI server to help achieve the same.

### Installation and usage

To install (or update to the latest version) using the bundler gem. Add this line to your application's Gemfile:

```
gem 'continuous_integration'
```

then run

```
bundle install
```

To install directly (without bundler), run

```
gem install continuous_integration
```

## Usage

Starting the server
```
server = ContinuousIntegration.run_ci
```

Shutting it down
```
ContinuousIntegration.shutdown_server server
```

### Troubleshooting

For help with common problems, see [TROUBLESHOOTING](doc/TROUBLESHOOTING.md).

Still stuck? Try [filing an issue](doc/contributing/ISSUES.md).

### Other questions

To see what has changed in recent versions of Bundler, see the [CHANGELOG](CHANGELOG.md).

To get in touch with the ContinuousIntegration core team and other Bundler users, please see [getting help](doc/contributing/GETTING_HELP.md).

### Contributing

If you'd like to contribute to ContinuousIntegration, that's awesome, and we <3 you. There's a guide to contributing to ContinuousIntegration (both code and general help) over in [our documentation section](doc/README.md).


#### Donations

Please feel free to donate as this work is made possible with donations like yours. It involves years of efforts with money spent to obtain the college degree and experience gained to write quality software. PM for customizations and implementations 

[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=ZKRHDCLG22EJA)

### Code of Conduct

Everyone interacting in the ContinuousIntegration project’s codebases, issue trackers, chat rooms, and mailing lists is expected to follow the [Bundler code of conduct](doc/CODE_OF_CONDUCT.md).
