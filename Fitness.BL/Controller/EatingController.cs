﻿using System;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Model;

namespace Fitness.BL.Controller
{
	public class EatingController : ControllerBase
	{
		private const string FOODS_FILE_NAME = "foods.dat";
		private const string EATINGS_FILE_NAME = "eatings.dat";
		private readonly User user;

		public List<Food> Foods { get; }
		public Eating Eating { get; }

		public EatingController(User user)
		{
			this.user = user ?? throw new ArgumentNullException("Пользователь не может быть равен нулю", nameof(user));

			Foods = GetAllFoods();
			Eating = GetEating();
		}


		public void Add(Food food, double weightproduct)
        {
			var product = Foods.SingleOrDefault(f => f.Name == food.Name);
			if (product == null)
            {
				Foods.Add(food);
				Eating.Add(food, weightproduct);
				Save();
            }
            else
            {
				Eating.Add(product, weightproduct);
				Save();
            }
		}

		private Eating GetEating()
        {
			return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);

		}

		private List<Food> GetAllFoods()
		{
			return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();

		}

		private void Save()
        {
			Save(FOODS_FILE_NAME, Foods);
			Save(EATINGS_FILE_NAME, Eating);
		}

	}
}

