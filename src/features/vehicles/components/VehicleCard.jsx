function VehicleCard({ vehicle, onBook }) {
  return (
    <div className="vehicle-card">
      <h3>{vehicle.name}</h3>
      <p>₹{vehicle.price} / day</p>
      <button onClick={() => onBook(vehicle)}>Book Now</button>
    </div>
  );
}

export default VehicleCard;