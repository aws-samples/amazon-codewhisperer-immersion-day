import StartPageOriginal from './StartPage';
import CalculatorPage from './CalculatorPage';
import VolumesPage from './VolumesPage';

// 'pages' contains the list of pages that will be rendered in the StartPage component
// and the navigation bar. Each page has a title, description, image, path, and
// we define the element that will be rendered in the page.
const pages = [
  {
    title: 'Calculator',
    description: 'Provides a simple calculator for integers. Supports +, -, *, / operations.',
    path: 'calculator',
    image: 'calculator.svg',
    element: <CalculatorPage />
  },
  {
    title: 'Volumes',
    description: 'Calculates volumes for 3D shapes. Let us know if you miss a shape!',
    path: 'volumes',
    image: 'volumes.svg',
    element: <VolumesPage />
  }
];

// We override the StartPage component and pass 'pages'
// to the component defined in ./StartPage.js.
//
// example:
//    <StartPage />
const StartPage = () => (<StartPageOriginal pages = {pages}/>);

// export all the pages
export {pages, StartPage, CalculatorPage, VolumesPage};
