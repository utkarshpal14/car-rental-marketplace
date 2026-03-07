import { Link, useNavigate } from "react-router-dom";

function Navbar() {
  const navigate = useNavigate();
  const user = localStorage.getItem("user");

  const handleLogout = () => {
    localStorage.removeItem("user");
    navigate("/login");
  };

  return (
    <nav style={{ padding: "10px", background: "#222", color: "white" }}>

      <h3 style={{ display: "inline", marginRight: "20px", color: "white" }}>
        Car Rental System
      </h3>

      {!user && (
        <>
          <Link to="/login" style={{ marginRight: "15px", color: "white" }}>Login</Link>
          <Link to="/register" style={{ marginRight: "15px", color: "white" }}>Register</Link>
        </>
      )}

      {user && (
        <>
          <Link to="/vehicles" style={{ marginRight: "15px", color: "white" }}>Vehicles</Link>
          <Link to="/bookings" style={{ marginRight: "15px", color: "white" }}>Bookings</Link>
          <button onClick={handleLogout}>Logout</button>
        </>
      )}
    </nav>
  );
}

export default Navbar;