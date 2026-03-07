import LoginForm from "../components/LoginForm";
import AuthLayout from "../components/AuthLayout";

function LoginPage() {
  return (
    <AuthLayout>
      <h2>Login</h2>
      <LoginForm />
    </AuthLayout>
  );
}

export default LoginPage;