function MyBookingsPage() {
  const bookedVehicle = JSON.parse(localStorage.getItem("bookedVehicle"));

  return (
    <div style={{ padding: "20px" }}>
      <h2>My Booking</h2>

      {bookedVehicle ? (
        <div>
          <h4>{bookedVehicle.name}</h4>
          <p>₹{bookedVehicle.price} / day</p>
        </div>
      ) : (
        <p>No bookings yet.</p>
      )}
    </div>
  );
}

export default MyBookingsPage;