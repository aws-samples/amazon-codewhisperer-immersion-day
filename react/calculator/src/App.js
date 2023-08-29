import React from 'react';
import { BrowserRouter, Outlet, Routes, Route} from 'react-router-dom';

import {Navigation, Layout} from './components';
import {pages, StartPage, CalculatorPage, VolumesPage} from './pages';

// pages: Array of objects with the following properties:
//   title: String
//   description: String
//   path: String
//   image: String
//   element: React.Component

// 'navigation' contains the title, logo, and links for the navigation bar.
const navigation = {
  title: 'AWSomeMath',
  logo: 'Pi-symbol.svg',
  links: pages.map(({title, path}) => ({title, path}))
}

// React component that renders the root-div for the application.
// We use a navigation bar at the top and a browser router to render the
// different pages. The page definitions are in the 'pages' object.
//
// example:
//   <App />
//

export default function App() {
  return (
    <>
      <Navigation {...navigation} />
      
      <BrowserRouter>
        <Routes>
          {/* main path: '/' */}
          <Route path='/' element={<Layout />}>
            <Route index element = {<StartPage />} />
            {
              // <tbd> please replace the static routes below and use data
              //       from the imported pages object.
            }
            <Route path='calculator' element = {<CalculatorPage />} />
            <Route path='volumes' element = {<VolumesPage />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </>
  );
}

