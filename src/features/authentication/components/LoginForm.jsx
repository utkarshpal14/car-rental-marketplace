import { useState } from "react";
import { useNavigate } from "react-router-dom";

function LoginForm() {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleSubmit = (e) => {
    e.preventDefault();

    // temporary login simulation
    localStorage.setItem("user", email);

    // redirect to vehicles page
    navigate("/vehicles");
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginTop: "20px" }}>
      <div>
        <input
          type="email"
          placeholder="Enter Email address"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
      </div>

      <div style={{ marginTop: "10px" }}>
        <input
          type="password"
          placeholder="Enter Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
      </div>

      <button type="submit" style={{ marginTop: "10px" }}>
        Login
      </button>

      <p style={{ marginTop: "10px" }}>
        Don't have an account? <a href="/register">Register</a>
      </p>
    </form>
  );
}

export default LoginForm;