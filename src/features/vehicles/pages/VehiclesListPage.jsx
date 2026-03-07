import { useNavigate } from "react-router-dom";

function VehiclesListPage() {
  const navigate = useNavigate();

  const vehicles = [
    { id: 1, name: "Honda City", price: 2500 },
    { id: 2, name: "Hyundai Creta", price: 3000 },
    { id: 3, name: "Swift Dzire", price: 2000 },
  ];

  const handleBook = (vehicle) => {
    localStorage.setItem("bookedVehicle", JSON.stringify(vehicle));
    navigate("/bookings");
  };

  return (
    <div style={{ padding: "20px" }}>
      <h2>Available Vehicles</h2>

      {vehicles.map((vehicle) => (
        <div
          key={vehicle.id}
          style={{
            border: "1px solid #ddd",
            padding: "10px",
            margin: "10px 0",
            borderRadius: "6px",
          }}
        >
          <h4>{vehicle.name}</h4>
          <p>₹{vehicle.price} / day</p>

          <button onClick={() => handleBook(vehicle)}>
            Book Now
          </button>
        </div>
      ))}
    </div>
  );
}

export default VehiclesListPage;