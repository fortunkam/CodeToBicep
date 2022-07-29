@description('This is a decorator')
@secure()
@allowed([
	'One'
	'Two'
])
param MyParamName string