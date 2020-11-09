use zahnradwerte;

insert into zahnradwerkstoffe (Art,Bezeichnung,Flankenhärte,Zahnfußdauerfestigkeit,Zahnflankendauerfestigkeit)
values ("Gußeisen mit Lamellengraphit", "EN-GJL-200", 190,55,330),
		("Gußeisen mit Lamellengraphit", "EN-GJL-250", 220,70,360),
        ("Schwarzer Temperguß", "EN-GJMB-350", 150,125,350),
        ("Schwarzer Temperguß", "EN-GJMB-650", 235,180,470),
        ("Schwarzer Temperguß", "EN-GJMB-650", 235,180,470),
        ("Gußeisen mit Kugelgraphit", "EN-GJS-400", 180,140,360),
        ("Gußeisen mit Kugelgraphit", "EN-GJS-600", 240,205,560),
        ("Gußeisen mit Kugelgraphit", "EN-GJS-900", 300,225,640),
        ("Stahlguß, unlegiert", "GS 200+N", 160,115,280),
        ("Stahlguß, unlegiert", "GS 240+N", 180,125,315),
        ("Allgemeine Baustähle", "S235JR", 120,125,315),
        ("Allgemeine Baustähle", "E295", 160,140,350),
        ("Allgemeine Baustähle", "E355", 190,160,375),
        ("Vergütungsstähle", "C45E N", 190,160,470),
        ("Vergütungsstähle", "34CrMo4+QT", 270,220,540),
        ("Vergütungsstähle", "42CrMo4+QT", 300,230,540),
        ("Vergütungsstähle", "34CrNiMo6+QT", 310,235,580),
        ("Vergütungsstähle", "30CrNiMo8+QT", 320,240,610),
        ("Vergütungsstähle", "36CrNiMo16+QT", 350,250,640),
        ("Vergütungsstähle", "C45E / 34CrMo4 / 42CrMo4 / 34CrNiMo6", 469,230,980),
        ("Vergütungsstähle", "42CrMo4+QT / 16MnCr5+QT", 456,260,780),
        ("Vergütungsstähle und Einsatzstähle", "C45E N", 277,225,650),
        ("Vergütungsstähle und Einsatzstähle carburiert", "16MnCr5N", 419,225,650),
        ("Vergütungsstähle und Einsatzstähle carbonitriert", "34Cr4+QT", 552,300,1100),
        ("Vergütungsstähle und Einsatzstähle einsatzgehärtet", "16MnCr5 / 15CrNi6 / 18CrNiMo7-6", 601,310,1300);
        
        
        
select* from zahnradwerkstoffe;