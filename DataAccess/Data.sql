INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Sengelinned', 30, 0);
INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Morgenkomplet(voksen)', 75, 0);
INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Morgenkomplet(b�rn)', 50, 0);
INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Slutreng�ring', 150, 0);
INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Cykelleje', 200, 1);
INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Adgang til badeland (voksen)', 30, 0);
INSERT INTO Additions(Name, Price, IsDailyPayment) VALUES('Adgang til badeland (b�rn)', 15, 0);

INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('2', 2, 0);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('3', 2, 0);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('4', 2, 0);

INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H1', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H1', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H2', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H2', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H3', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H3', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H4', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H4', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H5', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H5', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H7', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H7', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H8', 3, 1);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H8', 1, 1);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H10', 3, 0);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H10', 1, 2);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H11', 3, 0);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H11', 1, 2);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H12', 3, 0);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H12', 1, 2);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H13', 3, 0);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H13', 1, 2);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H14', 3, 0);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H14', 1, 2);
INSERT INTO Spots(Number, SpotType, IsGoodView) VALUES('H15', 3, 0);
INSERT INTO HutSpots(Number, IsCleaned, HutType) VALUES('H15', 1, 2);


 enum SpotType
    {
        TentSite = 1,
        CampingSite = 2,
        HutSite = 3,
    };
    public enum HutType
    {
        Default = 1,
        Luxury = 2,
    }