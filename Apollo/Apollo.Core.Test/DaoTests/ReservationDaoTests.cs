using Apollo.Core.Daos;
using Apollo.Core.Interface.Daos;
using Apollo.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Apollo.Core.Test
{
    public class ReservationDaoTests
    {
        static string BaseDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\";
        static IConfiguration config = ConfigurationUtil.GetConfiguration(BaseDirectory);
        static IConnectionFactory connectionFactory = DefaultConnectionFactory.FromConfiguration(config, "ApolloTestDbConnection");
        IReservationDao reservationDao = new MSSQLReservationDao(connectionFactory);
        IShowDao showDao = new MSSQLShowDao(connectionFactory);

        [Fact]
        public async void InsertAsyncTest()
        {
            Movie movie = new Movie("Life of Pi", "Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh.", "Comedy|Romance", 138.01, "Palmer Martynov", "http://dummyimage.com/137x173.jpg/ff4444/ffffff", "http://plala.or.jp/blandit/non.js?vulputate=nisi&ut=at&ultrices=nibh&vel=in&augue=hac&vestibulum=habitasse&ante=platea&ipsum=dictumst&primis=aliquam&in=augue&faucibus=quam&orci=sollicitudin&luctus=vitae&et=consectetuer&ultrices=eget&posuere=rutrum&cubilia=at&curae=lorem&donec=integer&pharetra=tincidunt&magna=ante&vestibulum=vel&aliquet=ipsum&ultrices=praesent&erat=blandit&tortor=lacinia&sollicitudin=erat&mi=vestibulum&sit=sed&amet=magna&lobortis=at&sapien=nunc&sapien=commodo&non=placerat&mi=praesent&integer=blandit&ac=nam&neque=nulla&duis=integer&bibendum=pede&morbi=justo&non=lacinia&quam=eget&nec=tincidunt&dui=eget&luctus=tempus&rutrum=vel&nulla=pede&tellus=morbi&in=porttitor&sagittis=lorem&dui=id&vel=ligula&nisl=suspendisse&duis=ornare&ac=consequat&nibh=lectus&fusce=in&lacus=est&purus=risus&aliquet=auctor&at=sed&feugiat=tristique&non=in&pretium=tempus&quis=sit&lectus=amet&suspendisse=sem&potenti=fusce&in=consequat");
            CinemaHall cinemaHall = new CinemaHall("HALL 5", 9, 19);
            Show show = new Show(new DateTime(2021, 01, 26, 14, 45, 00), movie, cinemaHall);
            Reservation reservation = new Reservation(300, 5, show);
            ICollection<Reservation> reservations = (ICollection<Reservation>)await reservationDao.FindAllAsync();
            Assert.Equal(4, reservations.Count);
            long reservationId = await reservationDao.InsertAsync(reservation);
            reservations = (ICollection<Reservation>)await reservationDao.FindAllAsync();
            Assert.Equal(5, reservations.Count);
            Assert.NotEqual(300, reservationId);
            await reservationDao.DeleteAsync(reservation);
        }

        [Fact]
        public async void FindAllAsyncTest()
        {
            ICollection<Reservation> reservations = (ICollection<Reservation>)await reservationDao.FindAllAsync();
            Assert.Equal(4, reservations.Count);
        }

        [Fact]
        public async void FindByIdAsyncTest()
        {
            Reservation reservation = await reservationDao.FindByIdAsync(60042);
            Assert.Equal("IMAX HALL 1", reservation.Show.CinemaHall.Name);
        }

        [Fact]
        public async void FindByShowAsyncTest()
        {
            Movie movie = new Movie("Strawberry Blonde, The", "Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh.", "Comedy|Romance", 138.01, "Palmer Martynov", "http://dummyimage.com/137x173.jpg/ff4444/ffffff", "http://plala.or.jp/blandit/non.js?vulputate=nisi&ut=at&ultrices=nibh&vel=in&augue=hac&vestibulum=habitasse&ante=platea&ipsum=dictumst&primis=aliquam&in=augue&faucibus=quam&orci=sollicitudin&luctus=vitae&et=consectetuer&ultrices=eget&posuere=rutrum&cubilia=at&curae=lorem&donec=integer&pharetra=tincidunt&magna=ante&vestibulum=vel&aliquet=ipsum&ultrices=praesent&erat=blandit&tortor=lacinia&sollicitudin=erat&mi=vestibulum&sit=sed&amet=magna&lobortis=at&sapien=nunc&sapien=commodo&non=placerat&mi=praesent&integer=blandit&ac=nam&neque=nulla&duis=integer&bibendum=pede&morbi=justo&non=lacinia&quam=eget&nec=tincidunt&dui=eget&luctus=tempus&rutrum=vel&nulla=pede&tellus=morbi&in=porttitor&sagittis=lorem&dui=id&vel=ligula&nisl=suspendisse&duis=ornare&ac=consequat&nibh=lectus&fusce=in&lacus=est&purus=risus&aliquet=auctor&at=sed&feugiat=tristique&non=in&pretium=tempus&quis=sit&lectus=amet&suspendisse=sem&potenti=fusce&in=consequat");
            CinemaHall cinemaHall = new CinemaHall("SAAL 3", 9, 19);
            Show show = new Show(new DateTime(2020, 11, 26, 12, 33, 48), movie, cinemaHall);
            ICollection<Reservation> reservations = (ICollection<Reservation>)await reservationDao.FindByShowAsync(show);
            Assert.Equal(0, reservations.Count);
        }

        [Fact]
        public async void UpdateAsyncTest()
        {
            Reservation updatedReservation = await reservationDao.FindByIdAsync(60042);
            Reservation result = await reservationDao.FindByIdAsync(60042);
            updatedReservation.MaxSeats = 100;
            Assert.NotEqual(updatedReservation.MaxSeats, result.MaxSeats);
            await reservationDao.UpdateAsync(updatedReservation);
            Reservation result2 = await reservationDao.FindByIdAsync(60042);
            Assert.Equal(updatedReservation.MaxSeats, result2.MaxSeats);
            await reservationDao.UpdateAsync(result);
        }

        [Fact]
        public async void DeleteAsyncTest()
        {
            Movie movie = new Movie("Life of Pi", "Nulla mollis molestie lorem. Quisque ut erat. Curabitur gravida nisi at nibh.", "Comedy|Romance", 138.01, "Palmer Martynov", "http://dummyimage.com/137x173.jpg/ff4444/ffffff", "http://plala.or.jp/blandit/non.js?vulputate=nisi&ut=at&ultrices=nibh&vel=in&augue=hac&vestibulum=habitasse&ante=platea&ipsum=dictumst&primis=aliquam&in=augue&faucibus=quam&orci=sollicitudin&luctus=vitae&et=consectetuer&ultrices=eget&posuere=rutrum&cubilia=at&curae=lorem&donec=integer&pharetra=tincidunt&magna=ante&vestibulum=vel&aliquet=ipsum&ultrices=praesent&erat=blandit&tortor=lacinia&sollicitudin=erat&mi=vestibulum&sit=sed&amet=magna&lobortis=at&sapien=nunc&sapien=commodo&non=placerat&mi=praesent&integer=blandit&ac=nam&neque=nulla&duis=integer&bibendum=pede&morbi=justo&non=lacinia&quam=eget&nec=tincidunt&dui=eget&luctus=tempus&rutrum=vel&nulla=pede&tellus=morbi&in=porttitor&sagittis=lorem&dui=id&vel=ligula&nisl=suspendisse&duis=ornare&ac=consequat&nibh=lectus&fusce=in&lacus=est&purus=risus&aliquet=auctor&at=sed&feugiat=tristique&non=in&pretium=tempus&quis=sit&lectus=amet&suspendisse=sem&potenti=fusce&in=consequat");
            CinemaHall cinemaHall = new CinemaHall("HALL 5", 9, 19);
            Show show = new Show(new DateTime(2021, 01, 26, 14, 45, 00), movie, cinemaHall);
            Reservation reservation = new Reservation(300, 5, show);
            Assert.False(await reservationDao.DeleteAsync(reservation));
            await reservationDao.InsertAsync(reservation);
            Assert.True(await reservationDao.DeleteAsync(reservation));
        }
    }
}