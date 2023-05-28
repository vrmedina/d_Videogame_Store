USE [d_Videogame_Store_DB]
GO

INSERT INTO [dbo].[Users]
           ([Username]
           ,[PasswordHash]
           ,[PasswordSalt]
           ,[Role])
     VALUES
           ('string', 0xFFAFA69477447E5170BF886CD3C179C5CF59FDE2EB36C1D018C9A90206E987BF6D20E0481178AC2FC06511DB76664F2597F77640CAD185B45D95E891AA194476, 0x9721F03E50A59031FCF3D22EB814D2AC8EE00FD71DCF6FBE2D59F1E75D6876605EB18CEF5201B4EA34D8D5019735ECD167FAEC10B56A0F5CF9A8A63D91EA0E654078BDB078F47D4EA5776DA591D0A73E3BD15D439A280EF7023D9A7E6320039BBA98D1870EFAD845A749EBC5E4C01675E8AD65F9C771F86B457EEB4D73737663, 1),
           ('jhon', 0xA70FD9BFCDC935C03D49197758AFD148A5FF905D81DCCCC2533079ADA34EC87990D12EF28754D49ADB9503071ED2029B9AEF0696F3EA9A4F3813A9B94F91A7A2, 0xB472753CE4E662844C05677416408735CA62869ECF59F51FB8BA46A9AA1817EE967A235DCF3E2865035FC78D08F9DAB62493C133FD9F4F2D80CF90656A25307CCA95A4F9010793556D96F63F9285F56A10A5F2277C609AB9ADDDEFBE823EA67E2D87BE553D870B8494DD2370B839565711909C2A7BCE5F0C8FA8A3355C2756E9, 1),
           ('victor', 0xAE633C15D586E20DEC33EA7A6C3C61340F61C2517F80AEB41ED98B794828B1F309732478444C4AD18CE734CA2F6A867C4927B9F66514AF7E27D8B86807C9799E, 0xB4B075CA3EF5997E9B71707360892E73697967A04F8078F99D162614613915943EBEB5CCAB4505F3789025CB4B45A5A20698B6B0E0C6D9A29015F6B07EF3B6FD4458673892DE7C67F06F37C4C7B4E27944F0E2225B87FA106863E63CD1E23996077A5F61A2966D1F6093A063B0C599C961B24E43D915FDC613F9584C1A6D874B, 1),
           ('raul', 0x7F0671E6DFB8033A949E4B834893041DD27BA4C20BECBD4072BDB596FBA93E803FFA511FB3A25471B9F69FDEABDF57BCF68FEF84CBBF082407451DD628D44121, 0x9279D494B55A6625B87BA989EB907DAD2E3FC4410F6810748E733E0D5C8184266215016C3BACA6D36E9FD40EF4FC613AC61B59D46FA46C3500095D794CD57638D4CC6BC410F36415E1627714A2A8F1A3339A99D230ECDBF4A99C5A818BA082FD46ECAE9DB710EA8692EB70E0AD83513C01E48E8EB976C2A8C4043FBC5D3E1663, 2),
           ('pedro', 0xE48D69A5F547D95629778CB98A1DC150B2EA217DFB9BBD9F27BE9B9FB63987098BAA82F3CDF101C08ACC9AED7E2C5555D99FD47FC1B67F38C526C676307E8CFE, 0x8047F6EE34512FFB24A1EA7720B5B13546F39F70BF47D224EF17E9E453EE74BAA71156D9EBCAEBDDBBC4F04E281B50388FBE6726C76FCD9879D257D3252024B503E2E0FA8101118081098F2BCE7465860D56A3F9F1813F20CE321146368EBA6A205D2EA277AA8FB22A694C1D84614ED65F5A58C0664B3814595334A6ED8E7B6D, 2),
           ('daniel', 0xDB5AD88BA8BDD84975A2D9CC65531D28832EEA4EE964FB287E845872E72E83204214A3D252DEFA2A20BAB2E3525CB96A2B65AE59B98686E84A9F17711007364D, 0xBAA32759D8155602A14884C67B8D54F125C25A69B19DFD6B33A4B721BCA3862D5CF18F83E34CCC74A814DB50CC3068F0AC4A86C0FE608856D80F5AB96041219083ECA89F5CC6CA3D6B302E692FD32A78852EE8427A8D8671C7E0546E18154588BAF7BFDD662C5819C165795F61F2B0DCCA81F3DDEE63D97568C6A6C84E903649, 2),
           ('maria', 0x5CB4230D0FCF40CD873D74E708F371648A2C2E48AD5E7F08A2930EB838DDE2DC7182007ABAF32A9E37BF7C2122C4C866F58BBC03085AB377B2F1913817DCB566, 0x33B7E6B543C8E9151D8D2BD61A201E4B92731363AA28EF0400B02754DBA2FCF5119F65D5D5D11A2162891F32B65FD561E6195540F15D286F5C3F13F94B01109A66AE39A1D7A50E628FDC935A12016FD58935B350DF72368DD47B80A4F02AD0939F6DD4AF862FDADFC6A0DE4A4FF08957D25F0797646F2C6C11F7B178B8E91307, 2),
           ('mercedes', 0x179C1AD5FE24BF5C2865811B360A215DFB27E41EA9B5601CEB5AE80693218EF73FEB171458822AE6B50B98CFA7600A6771A7009CE75BCBF5C20F740616A139FA, 0x8690CDE453BC700A2BD1484A1E4130BFA2D1DAB153BA539BE460989FAA2D3145FA2B6C0942562717E60D9A3C22F8C57471401875C3BDA78C8CDCEAB60AAE2E4B2039A6962328022D51917AC7CF24C4223E688F67C9048779BCFD3F64212113439D457B0ADE3DE6475C4A997EB36E4756FF31CC5ECA9CC14F4EC19F748DA072E7, 2),
           ('claudia', 0xF9E7735F010BBC5BF4F4843B5E2B17479B09B2A47A69A3C2EB76C121F0636C5BD1AEDB63A5266ED394477FD21E7E61F04B0F7B3D38C02A54E2EB172BB43F6609, 0x607084DDA2FFC43FE6D883DDC32A037B290856EC491716FEBF10946E23D433798A2E3140805B64881BFAF44657DAD931C60E55A30F394DFAA8542D69E1E049F000573AC7215C0B825325236E6C441850CC2CC0632C2D4A0D17C04206704E7C4079F66B7D855CD069B5C925600D57700DC20F7D72406AC3961B24C150B82C960E, 2),
           ('daniela', 0x4AC822EC66EC4EEE8A7F581D671743DDE2FD188BBF0BF0E27C501C68BBE500EC4C344F2E8F4CB33061E937EF46864DF2870A12AB727C2F063171BEC84513B8F2, 0xD657B016C6AA10EF2B1FAD2339FEAF124E6362498BBE58C1498A0C7EDFD01BEB80D70E68A408F268F2D12FBBAA23F1E8E3BB9FEEE9018222181884DAF6F98C58222DA6B8DAE0481D2BD8C819C4DE47F51DB2337F322B83918692AF36699F0F08DBC71AAC1FA0E5E4E7705D67CCF27911EEFB2A37925DEB418D2F5B07FD9D89F2, 2)
GO


