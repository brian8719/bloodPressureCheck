Feature: Calculator

@BloodPressure
Scenario: Low Blood Pressure
	Given the SystolicValue is 80
	When the Diastolic Value is 50
	Then the result should be Low

@BloodPressure	
Scenario: Pre-High Blood Pressure
	Given the SystolicValue is 130
	When the Diastolic Value is 70
	Then the result should be PreHigh

@BloodPressure	
Scenario: High Blood Pressure
	Given the SystolicValue is 170
	When the Diastolic Value is 50
	Then the result should be High

@BloodPressure	
Scenario: Ideal Blood Pressure
	Given the SystolicValue is 105
	When the Diastolic Value is 70
	Then the result should be Ideal