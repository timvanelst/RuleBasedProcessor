Functionaliteit: QueueProcessorScenarios

Scenario: Basisscenario
	Stel de volgende klokmomenten worden aangeboden
		| TimeStamp        | 
		| 2016-05-18 14:30 |      
	Als de kloktijden worden verwerkt
	Dan zijn er de volgende kloktijden
		| TimeStamp        | Type |
		| 2016-05-18 14:30 |      |

Scenario: Klokken met inkloktype
	Stel de volgende klokmomenten worden aangeboden
		| TimeStamp        | Type |
		| 2016-05-18 14:30 | in   |
	Als de kloktijden worden verwerkt
	Dan zijn er de volgende kloktijden
		| TimeStamp        | Type |
		| 2016-05-18 14:30 | in   |

Abstract Scenario: Klokken met inkloktypes
	Stel de volgende klokmomenten worden aangeboden
		| TimeStamp        | Type    |
		| 2016-05-18 14:30 | <input> |
	Als de kloktijden worden verwerkt
	Dan zijn er de volgende kloktijden
		| TimeStamp        | Type                 |
		| 2016-05-18 14:30 | <verwacht resultaat> |

Voorbeelden: 
	| input   | verwacht resultaat |
	| in      | in                 |
	| inkpl   | in                 |
	| uit     | out                |
	| in_gate | onpremises         |