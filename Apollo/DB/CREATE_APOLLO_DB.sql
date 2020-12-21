CREATE TABLE Movie (
  Title VARCHAR(500) PRIMARY KEY,
  MovieDescription VARCHAR(3000),
  Genre VARCHAR(50),
  MovieLength FLOAT CHECK(MovieLength BETWEEN 1.0 AND 500.0),
  Actors VARCHAR(500),
  ImageURL VARCHAR(500),
  TrailerURL VARCHAR(3000)
);

CREATE TABLE SeatCategory (
  CategoryName VARCHAR(50) PRIMARY KEY,
  Price DECIMAL NOT NULL
);

CREATE TABLE CinemaHall (
  HallName VARCHAR(50) PRIMARY KEY,
  RowAmount INTEGER DEFAULT 0,
  SeatAmount INTEGER DEFAULT 0
);

CREATE TABLE Show (
  StartsAt DATETIME2,
  shows VARCHAR(500),
  playsIn VARCHAR(50),
  PRIMARY KEY (StartsAt, shows, playsIn),
  CONSTRAINT FK_shows
    FOREIGN KEY (shows)
    REFERENCES Movie(Title),
  CONSTRAINT FK_playsIn
    FOREIGN KEY (playsIn)
    REFERENCES CinemaHall(HallName)
);

CREATE TABLE Reservation (
  Id BIGINT PRIMARY KEY IDENTITY,
  MaxSeats INTEGER DEFAULT 10,
  showBegins DATETIME2,
  showMovie VARCHAR(500),
  showIn VARCHAR(50),
  CONSTRAINT FK_show
    FOREIGN KEY (showBegins, showMovie, showIn)
    REFERENCES Show(StartsAt, shows, playsIn)
);

CREATE TABLE Seat (
  SeatNumber INTEGER,
  RowNumber INTEGER,
  locatedIn VARCHAR(50),
  category VARCHAR(50),
  PRIMARY KEY (SeatNumber, RowNumber, locatedIn),
  CONSTRAINT FK_locatedIn
    FOREIGN KEY (locatedIn)
    REFERENCES CinemaHall(HallName),
  CONSTRAINT FK_category
    FOREIGN KEY (category)
    REFERENCES SeatCategory(CategoryName)
);

CREATE TABLE reservedSeat (
  seatNumber INTEGER,
  seatRow INTEGER,
  seatLocation VARCHAR(50),
  reservationId BIGINT,
  PRIMARY KEY (seatNumber, seatRow, seatLocation, reservationId),
  CONSTRAINT FK_seat
    FOREIGN KEY (seatNumber, seatRow, seatLocation)
    REFERENCES Seat(SeatNumber, RowNumber, locatedIn),
  CONSTRAINT FK_reservationId
    FOREIGN KEY (reservationId)
    REFERENCES Reservation(Id)
);


