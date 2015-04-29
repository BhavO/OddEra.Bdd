Feature: As User of the ExampleApp 
I want to be able access and login the ExampleApp

Scenario: Organisation level test of App - subscribed user
Given that David does not have a subscription to the ExampleApp service
When David logs in to the App
Then David will not see any reference to the ExampleApp admin console on the menu 

Scenario: User Role A access  - subscribed user
Given that David does not have a subscription to the ExampleApp service
When David logs in to the App
Then David will not see any reference to the ExampleApp admin console on the menu 

Scenario: User Role B access - subscribed user
Given that David does have a subscription to the ExampleApp service
When David logs in to the App
Then David will see the ExampleApp admin console on the menu 

Scenario: User Role A access - unsubscribed user
Given that David does not have a subscription to the ExampleApp service
When David logs in to the App
Then David will not see any reference to the ExampleApp admin console on the menu 

Scenario: User Role B access - unsubscribed user
Given that John does not have a subscription to the ExampleApp service
When John logs in to the App
Then John will see the ExampleApp admin console on the menu 
