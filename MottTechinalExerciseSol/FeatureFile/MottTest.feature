Feature: MottTest
	Browse Mott mac website to test all the scenarioes.

@mytag
Scenario Outline: Browse Mott UI links
	Given the user is on 'https://www.mottmac.com'
	When the user clicked on '<menu>' tab
	Then new '<menu>' tab page should load

Examples: 
	| menu      |
	| About us  |
	| Digital   |
	| Sectors   |
	| Expertise |



@mytag
Scenario: Seach a Job
	Given the user is on 'https://www.mottmac.com/careers/search'
	When the user search for 'Software engineer'
	Then verify the result contains 'Software engineer' role
	And clicks on 'View Job'