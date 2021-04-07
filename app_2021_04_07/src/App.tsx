import './App.css';
import NotificationSettings from './components/NotificationSetting';
import RatingBar from './components/RatingBar';

function App() {
  return (
    <div className="container">
      <div className="row">
        <NotificationSettings />
        <RatingBar />
      </div>
    </div>
  );
}

export default App;
