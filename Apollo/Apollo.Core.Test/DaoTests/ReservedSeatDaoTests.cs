using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xunit;

namespace Apollo.Core.Test
{
    public class ReservedSeatDaoTests
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");
        IReservedSeatDao reservedSeatDao = new MSSQLReservedSeatDao(connectionFactory);

        [Fact]
        public async void InsertAndDeleteAsyncTest()
        {
            Movie movie = new Movie("Life of Pi", "Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh.", "Comedy|Romance", 138.01, "Palmer Martynov", "http://dummyimage.com/137x173.jpg/ff4444/ffffff", "http://plala.or.jp/blandit/non.js?vulputate=nisi&ut=at&ultrices=nibh&vel=in&augue=hac&vestibulum=habitasse&ante=platea&ipsum=dictumst&primis=aliquam&in=augue&faucibus=quam&orci=sollicitudin&luctus=vitae&et=consectetuer&ultrices=eget&posuere=rutrum&cubilia=at&curae=lorem&donec=integer&pharetra=tincidunt&magna=ante&vestibulum=vel&aliquet=ipsum&ultrices=praesent&erat=blandit&tortor=lacinia&sollicitudin=erat&mi=vestibulum&sit=sed&amet=magna&lobortis=at&sapien=nunc&sapien=commodo&non=placerat&mi=praesent&integer=blandit&ac=nam&neque=nulla&duis=integer&bibendum=pede&morbi=justo&non=lacinia&quam=eget&nec=tincidunt&dui=eget&luctus=tempus&rutrum=vel&nulla=pede&tellus=morbi&in=porttitor&sagittis=lorem&dui=id&vel=ligula&nisl=suspendisse&duis=ornare&ac=consequat&nibh=lectus&fusce=in&lacus=est&purus=risus&aliquet=auctor&at=sed&feugiat=tristique&non=in&pretium=tempus&quis=sit&lectus=amet&suspendisse=sem&potenti=fusce&in=consequat");
            CinemaHall cinemaHall = new CinemaHall("HALL 5", 9, 19);
            Show show = new Show(new DateTime(2021, 01, 26, 14, 45, 00), movie, cinemaHall);
            Reservation reservation = new Reservation(16, 5, show);
            int seatNumber = 14;
            int seatRow = 6;
            Assert.False(await reservedSeatDao.DeleteAsync(reservation, seatNumber, seatRow));
            await reservedSeatDao.InsertAsync(reservation, seatNumber, seatRow);
            Assert.False(await reservedSeatDao.DeleteAsync(reservation, seatNumber, seatRow));
        }

        [Fact]
        public async void IsReservedAsyncTest()
        {
            Movie movie = new Movie("Life of Pi", "Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh.", "Comedy|Romance", 138.01, "Palmer Martynov", "http://dummyimage.com/137x173.jpg/ff4444/ffffff", "http://plala.or.jp/blandit/non.js?vulputate=nisi&ut=at&ultrices=nibh&vel=in&augue=hac&vestibulum=habitasse&ante=platea&ipsum=dictumst&primis=aliquam&in=augue&faucibus=quam&orci=sollicitudin&luctus=vitae&et=consectetuer&ultrices=eget&posuere=rutrum&cubilia=at&curae=lorem&donec=integer&pharetra=tincidunt&magna=ante&vestibulum=vel&aliquet=ipsum&ultrices=praesent&erat=blandit&tortor=lacinia&sollicitudin=erat&mi=vestibulum&sit=sed&amet=magna&lobortis=at&sapien=nunc&sapien=commodo&non=placerat&mi=praesent&integer=blandit&ac=nam&neque=nulla&duis=integer&bibendum=pede&morbi=justo&non=lacinia&quam=eget&nec=tincidunt&dui=eget&luctus=tempus&rutrum=vel&nulla=pede&tellus=morbi&in=porttitor&sagittis=lorem&dui=id&vel=ligula&nisl=suspendisse&duis=ornare&ac=consequat&nibh=lectus&fusce=in&lacus=est&purus=risus&aliquet=auctor&at=sed&feugiat=tristique&non=in&pretium=tempus&quis=sit&lectus=amet&suspendisse=sem&potenti=fusce&in=consequat");
            CinemaHall cinemaHall = new CinemaHall("HALL 5", 9, 19);
            Show show = new Show(new DateTime(2021, 01, 26, 14, 45, 00), movie, cinemaHall);
            Reservation reservation = new Reservation(14, 5, show);
            Assert.False(await reservedSeatDao.IsReservedAsync(reservation, 16, 6));
        }
    }
}