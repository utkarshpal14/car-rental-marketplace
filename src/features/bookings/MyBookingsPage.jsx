function MyBookingsPage() {
  const bookedVehicle = JSON.parse(localStorage.getItem("bookedVehicle"));

  return (
    <div className="container">
      <h2>My Booking</h2>

      {bookedVehicle ? (
        <div className="vehicle-card">
          <h3>{bookedVehicle.name}</h3>
          <p>₹{bookedVehicle.price} / day</p>
        </div>
      ) : (
        <p>No bookings yet.</p>
      )}
    </div>
  );
}

export default MyBookingsPage;