using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentLibrary.Models
{
	/// <summary>
	/// Represents one person.
	/// </summary>
	public class PersonModel
	{
		/// <summary>
		/// Unique identidier for person.
		/// </summary>
		public int Id { get; set; }
        /// <summary>
        /// The first name of the person.
        /// </summary>
        public string FirstName { get; set; }
		/// <summary>
		/// The last name of the person.
		/// </summary>
		public string LastName { get; set; }
		/// <summary>
		/// The email address of the person.
		/// </summary>
		public string EmailAddress { get; set; }
		/// <summary>
		/// The primary cell phone number of the person.
		/// </summary>
		public string CellphoneNumber { get; set; }
        public string FullName 
		{ 
			get 
			{
				return $"{FirstName} {LastName}";
			} 
		}
        public PersonModel() { }
		public PersonModel (string firstName, string lastName, string emailAddress, string cellphoneNumber)
        {
			FirstName = firstName;
			LastName = lastName;
			EmailAddress = emailAddress;
			CellphoneNumber = cellphoneNumber;
        }
	}
}
