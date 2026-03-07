import { Routes, Route } from "react-router-dom";

import LoginPage from "../features/authentication/pages/LoginPage";
import RegisterPage from "../features/authentication/pages/RegisterPage";
import VehiclesListPage from "../features/vehicles/pages/VehiclesListPage";
import MyBookingsPage from "../features/bookings/MyBookingsPage";
import PaymentPage from "../features/payments/pages/PaymentPage";

function AppRoutes() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />

      <Route path="/vehicles" element={<VehiclesListPage />} />
      <Route path="/bookings" element={<MyBookingsPage />} />
      <Route path="/payment" element={<PaymentPage />} />

      <Route path="*" element={<LoginPage />} />
    </Routes>
  );
}

export default AppRoutes;