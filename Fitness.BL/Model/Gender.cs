﻿namespace Fitness.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
	public class Gender
	{
		/// <summary>
		/// Название
		/// </summary>
		public string Name { get; }

		/// <summary>
        /// создать новый пол
        /// </summary>
        /// <param name="name"> Имя пола. </param>
        /// <exception cref="ArgumentNullException"></exception>
        
		public Gender(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException("Имя пола не может быть пустым или Null", nameof(name));

			}
			Name = name;


		}
        public override string ToString()
        {
            return Name;

        }
    }

}

