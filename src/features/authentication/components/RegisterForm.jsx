function RegisterForm() {
  return (
    <form>
      <input type="text" placeholder="Enter Name" />
      <br /><br />
      <input type="email" placeholder="Enter Email" />
      <br /><br />
      <input type="password" placeholder="Enter Password" />
      <br /><br />
      <button type="submit">Register</button>
    </form>
  );
}

export default RegisterForm;