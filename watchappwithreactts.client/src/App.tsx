import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Layout from './components/layout/Layout';
import Home from './pages/Home';
import MovieDetail from './pages/MovieDetail';
import WatchMovie from './pages/WatchMovie';
import './App.css';

function App() {
    return (
        <Router>
            <Layout>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/movie/:id" element={<MovieDetail />} />
                    <Route path="/watch/:id" element={<WatchMovie />} />
                </Routes>
            </Layout>
        </Router>
    );
}

export default App;