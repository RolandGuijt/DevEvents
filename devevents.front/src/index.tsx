import * as React from 'react';
import * as ReactDOM from 'react-dom';
import MainPage from './main-page';
import './index.css';
import registerServiceWorker from './registerServiceWorker';

ReactDOM.render(
  <MainPage />,
  document.getElementById('root') as HTMLElement
);
registerServiceWorker();
