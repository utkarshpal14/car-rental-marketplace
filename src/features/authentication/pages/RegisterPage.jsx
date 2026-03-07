import RegisterForm from "../components/RegisterForm";
import AuthLayout from "../components/AuthLayout";

function RegisterPage() {
  return (
    <AuthLayout>
      <h2>Register</h2>
      <RegisterForm />
    </AuthLayout>
  );
}

export default RegisterPage;