import './App.css';
import AppRoutes from './routes/AppRoutes';
import Navbar from './shared/components/Navbar';
import Footer from './shared/components/Footer';

function App() {
  return (
    <>
      <Navbar />
      <AppRoutes />
      <Footer />
    </>
  );
}

export default App;