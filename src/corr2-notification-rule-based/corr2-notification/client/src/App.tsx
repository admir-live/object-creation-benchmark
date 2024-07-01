import React, { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';

function App() {
  const [notifications, setNotifications] = useState([]);

  useEffect(() => {
    const connection = new signalR.HubConnectionBuilder()
      .withUrl("http://localhost:5224/hubs/notification", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .withAutomaticReconnect()
      .build();

    connection.on("ReceiveNotification", (message) => {
      setNotifications(prevNotifications => [...prevNotifications, message]);
    });

    connection.start()
      .then(() => console.log('Connection started'))
      .catch(error => console.error('Connection failed: ', error));

    return () => {
      if (connection.state === signalR.HubConnectionState.Connected) {
        connection.stop()
          .then(() => console.log('Connection stopped'))
          .catch(error => console.error('Failed to stop connection: ', error));
      }
    };
  }, []);

  return (
    <div className="App">
      <h1>Notifications</h1>
      <ul>
        {notifications.map((notification, index) => (
          <li key={index}>{notification}</li>
        ))}
      </ul>
    </div>
  );
}

export default App;
