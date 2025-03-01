﻿using Expenses.DB;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Expenses.Core
{
	public class ExpensesServices : IExpensesServices
	{
		private AppDbContext _context;
		public ExpensesServices(AppDbContext context) 
		{
			_context = context;
		}

		public Expense CreateExpense(Expense expense)
		{
			_context.Add(expense);
			_context.SaveChanges();

			return expense;
		}

		public void DeleteExpense(Expense expense)
		{
			_context.Expenses.Remove(expense);
			_context.SaveChanges();
		}

		public Expense GetExpense(int id)
		{
			return _context.Expenses.FirstOrDefault(x => x.Id == id);
		}

		public List<Expense> GetExpenses()
		{
			return _context.Expenses.ToList();
		}

		public Expense UpdateExpense(Expense expense)
		{
			var dbExpense = _context.Expenses.First(e=>e.Id == expense.Id);
			dbExpense.Description = expense.Description;
			dbExpense.Amount = expense.Amount;
			_context.SaveChanges();

			return dbExpense;
		}
	}
}
