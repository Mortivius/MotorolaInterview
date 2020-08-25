using Xunit;
using System.IO;
using System;
using System.Collections.Generic;

namespace MarsRover {
    public class TestClass {
        // I follow Roy Osherove's convention, ie
        // UnitOfWork_StateUnderTest_ExpectedBehavior
        [Fact]
        public void ReadLinesFromFile_BadFilenameProvided_ExceptionThrown() {
            Assert.Throws<FileNotFoundException>(() => Program.ReadLinesFromFile(@"xyz.txt"));
        }

        [Fact]
        public void ReadLinesFromFile_ValidFileFound_ListReturned() {
            Assert.IsType<List<String>>(Program.ReadLinesFromFile(@"/Users/peterstewart/Documents/Code/MotorolaInterview/App/testdates.txt"));
        }

        [Fact]
        public void ParseDateTimeFromString_InvalidDate_ExceptionCaughtAndEmptyDateTimeReturned() {
            Assert.Equal(new DateTime(), Program.ParseDateTimeFromString(@"April 31, 2018"));
        }

        [Fact]
        public void ParseDateTimeFromString_BadDateFormat_ExceptionCaughtAndEmptyDateTimeReturned() {
            Assert.Equal(new DateTime(), Program.ParseDateTimeFromString(@"ABC DEF GH"));
        }

        [Theory]
        [InlineData("April 3, 2018")]
        [InlineData("02/27/17")]
        [InlineData("Jul-13-2016")]
        [InlineData("June 2, 2017")]
        public void ParseDateTimeFromString_ValidDateAndFormat_ConversionSuccessful(string date) {
            Assert.IsType<DateTime>(Program.ParseDateTimeFromString(date));
        }

        [Fact]
        public void GetMarsRoverPhotosOnDate_OKStatusCodeReturned_DeserializationValid() {
            // this would work best with a full fledged mock API service
        }

        [Fact]
        public void DownloadFileFromUri_ValidUriProvided_FileDownloadedSuccessfully() {
            
        }

        [Fact]
        public void DownloadFileFromUri_InvalidUriProvided_ExceptionThrown() {

        }

        [Fact]
        public void OpenUrl_ValidUrlProvided_ProcessFired() {
            // would work best with a fake process class
        }

        [Fact]
        public void OpenUrl_InvalidUrlProvided_ProcessNotFired() {

        }
    }
}