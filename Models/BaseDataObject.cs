using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
namespace XamarinNavy.Models
{
	public class BaseDataObject : INotifyPropertyChanged
	{
		public BaseDataObject()
		{
			Id = Guid.NewGuid().ToString();
		}

		/// <summary>
		/// Id for item
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Azure created at time stamp
		/// </summary>
		public DateTimeOffset CreatedAt { get; set; }

		/// <summary>
		/// Azure UpdateAt timestamp for online/offline sync
		/// </summary>
		public DateTimeOffset UpdatedAt { get; set; }

		/// <summary>
		/// Azure version for online/offline sync
		/// </summary>
		public string AzureVersion { get; set; }


		/// <summary>
		/// Sets the property.
		/// </summary>
		/// <returns><c>true</c>, if property was set, <c>false</c> otherwise.</returns>
		/// <param name="backingStore">Backing store.</param>
		/// <param name="value">Value.</param>
		/// <param name="propertyName">Property name.</param>
		/// <param name="onChanged">On changed.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		protected bool SetObservableProperty<T>(
			ref T backingStore, T value,
			[CallerMemberName]string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		#region INotifyPropertyChanged 
		/// <summary>
		/// Occurs when property changed.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Raises the property changed event.
		/// </summary>
		/// <param name="propertyName">Property name.</param>
		protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion
	}
}
