INCLUDE Variables.ink

{dayOfCreation == 1: -> day1}
 
{dayOfCreation == 2: -> day2}
 
{dayOfCreation == 3: -> day3}
  
{dayOfCreation == 4: -> day4}

{dayOfCreation == 5: -> day5}

{dayOfCreation == 6: -> day6}

{dayOfCreation == 7: -> day7}

// --- Day 1 ---
=== day1 ===
Maligayang pagdating sa paglikha ng pisikal at espiritwal na daigdig, kapatid. Samahan mo akong tunghayan kung saan nagsimula ang lahat. #speaker:Character
Nang pasimula, nilikha ng Dios ang langit at ang lupa. Ang mundo noon ay wala pang anyo at wala pang laman. Ang tubig na bumabalot sa mundo ay balot ng kadiliman. At ang Espiritu ng Dios ay kumikilos sa ibabaw ng mga tubig. Sinabi ng Dios, #speaker:Narrator
Magkaroon ng Liwanag! #speaker:Ilaw(Dios)
~ eventNumber = 1
~ pauseDialogue = 0
At nagkaroon nga ng liwanag. Nasiyahan ang Dios sa liwanag na nakita niya. Pagkatapos, inihiwalay niya ang liwanag sa kadiliman. Tinawag niyang “araw” ang liwanag, at “gabi” naman ang kadiliman. #speaker:Narrator
~ pauseDialogue = 1
~ eventNumber = 2
~ newDay = 1
Lumipas ang gabi at dumating ang umaga. Iyon ang unang araw. Pagkatapos, sinabi ng Dios, #speaker:Narrator 
~ dayOfCreation = 2
->END

=== day2 ===
Magkaroon ng pagitan na maghihiwalay sa tubig sa dalawang bahagi. #speaker:Ilaw
~ eventNumber = 3
At nagkaroon nga ng pagitan na naghihiwalay sa tubig sa itaas at sa tubig sa ibaba. Ang pagitang itoʼy tinawag ng Dios na “kalawakan.”  #speaker:Narrator
Lumipas ang gabi at dumating ang umaga. Iyon ang ikalawang araw. Pagkatapos, sinabi ng Dios, #speaker:Narrator
~ dayOfCreation = 3
->END

=== day3 ===
Magsama sa isang lugar ang tubig sa mundo para lumitaw ang tuyong bahagi. #speaker:Ilaw 
~ eventNumber = 4
~ pauseDialogue = 0
At iyon nga ang nangyari. Tinawag niyang “lupa” ang tuyong lugar, at “dagat” naman ang nagsamang tubig. Nasiyahan ang Dios sa nakita niya. Pagkatapos, sinabi ng Dios, #speaker:Narrator 
~ pauseDialogue = 1
Magsitubo sa lupa ang lahat ng uri ng halaman, ang mga tanim na nagbubunga ng butil, at ang mga punongkahoy na namumunga ayon sa kani-kanilang uri. #speaker:Ilaw
~ eventNumber = 5
At iyon nga ang nangyari. Tumubo sa lupa ang lahat ng uri ng halaman, ang mga tanim na nagbubunga ng butil, at ang mga punongkahoy na namumunga ayon sa kani-kanilang uri. Nasiyahan ang Dios sa nakita niya. #speaker:Narrator
Lumipas ang gabi at dumating ang umaga. Iyon ang  ikatlong araw. Pagkatapos, sinabi ng Dios,#speaker:Narrator
~ dayOfCreation = 4
->END

=== day4 ===
Magkaroon ng mga ilaw sa kalangitan para ihiwalay ang araw sa gabi, at magsilbing palatandaan ng pagsisimula ng mga panahon, araw at taon. Magningning ang mga ito sa kalangitan para magbigayliwanag sa mundo. #speaker:Ilaw
~ eventNumber = 6
At iyon nga ang nangyari. Nilikha ng Dios ang dalawang malaking ilaw: ang pinakamalaki ay magliliwanag kung araw, at ang mas malaki ay magliliwanag kung gabi. Nilikha rin niya ang mga bituin. #speaker:Narrator
Inilagay ng Dios ang mga ito sa kalangitan para magbigay-liwanag sa mundo kung araw at gabi, at para ihiwalay ang liwanag sa dilim. At nasiyahan ang Dios sa nakita niya. Lumipas ang gabi at dumating ang umaga. #speaker:Narrator
Iyon ang ikaapat na araw. Pagkatapos, sinabi ng Dios, #speaker:Narrator
~ dayOfCreation = 5
->END

=== day5 ===
Magkaroon ng ibaʼt ibang hayop sa tubig at magsilipad ang ibaʼt ibang hayop sa himpapawid. #speaker:Ilaw
~ eventNumber = 7
Kaya nilikha ng Dios ang malalaking hayop sa dagat, at ang lahat ng uri ng hayop na nakatira sa tubig, at ang lahat ng uri ng hayop na lumilipad. Nasiyahan ang Dios sa nakita niya. At binasbasan niya ang mga ito. Sinabi niya, #speaker:Narrator
Magpakarami kayo, kayong mga hayop sa tubig at mga hayop na lumilipad. #speaker:Ilaw
Lumipas ang gabi at dumating ang umaga. Iyon ang ikalimang araw. Pagkatapos, sinabi ng Dios, #speaker:Narrator
~ dayOfCreation = 6
->END

=== day6 ===

Magkaroon ng ibaʼt ibang uri ng hayop sa lupa: mga hayop na maamo at mailap, malalaki at maliliit. #speaker:Ilaw
~ eventNumber = 8
At iyon nga ang nangyari. Nilikha ng Dios ang lahat ng ito at nasiyahan siya sa nakita niya. Pagkatapos, sinabi ng Dios, #speaker:Narrator 
Likhain natin ang tao ayon sa ating wangis. Sila ang mamamahala sa lahat ng uri ng hayop: mga lumalangoy, lumilipad, lumalakad at gumagapang. #speaker:Ilaw
~ eventNumber = 9
Kaya nilikha ng Dios ang tao, lalaki at babae ayon sa wangis niya. Binasbasan niya sila at sinabi, #speaker:Narrator
Magpakarami kayo para mangalat ang mga lahi ninyo at mamahala sa buong mundo. At pamahalaan ninyo ang lahat ng hayop.#speaker:Ilaw
Ibinibigay ko sa inyo ang mga tanim na namumunga ng butil pati ang mga punongkahoy na namumunga para inyong kainin. 30 At ibinibigay ko sa lahat ng hayop ang lahat ng luntiang halaman bilang pagkain nila. #speaker:Ilaw
At iyon nga ang nangyari. Pinagmasdan ng Dios ang lahat niyang nilikha at lubos siyang nasiyahan. #speaker:Narrator 
Lumipas ang gabi at dumating ang umaga. Iyon ang ikaanim na araw. #speaker:Narrator
~ dayOfCreation = 7
->END

=== day7 ===

Natapos likhain ng Dios ang kalangitan, ang mundo at ang lahat ng naroon. Natapos niya ito sa loob ng anim na araw at nagpahinga siya sa ikapitong araw. Binasbasan niya ang ikapitong araw at itinuring na di-pangkaraniwang araw, #speaker:Narrator
~ eventNumber = 10
dahil sa araw na ito nagpahinga siya nang matapos niyang likhain ang lahat. Ito ang salaysay tungkol sa paglikha ng Dios sa kalangitan at sa mundo. #speaker:Narrator

~ eventNumber = 11
Mahusay, kapatid! Natapos mo na ang unang aralin #speaker:Character

->END
