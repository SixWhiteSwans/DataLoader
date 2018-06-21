The configuration file is the App.config.

There are two folder locations that will need to be changed
PortfolioRiskData : inbound data
PortfolioRiskResults: out bound data

	<appSettings>
		<add key="PortfolioRiskData" value="D:\DataLoader\Data\Data.txt"></add>
		<add key="PortfolioRiskResults" value="D:\DataLoader\DataOutput\"></add>		
	</appSettings>



Major Assumption:
Its assumed that the tenor codes are in the correct sequencial format: y,m,w,d. If this is not the case then the risk bucket is considered invalid and and error will be printed.
The risk bucket will be excluded from the out risk file. 
The logic here is that if the tenor is not correctly formed then the risk itself potentially is wrong and should not be output as being correct risk.

