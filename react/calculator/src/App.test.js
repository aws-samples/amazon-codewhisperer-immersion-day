import { render, fireEvent, getByRole } from '@testing-library/react';
import { CalculatorPage, VolumesPage } from './pages'; 

// test cases for the calculator
describe('CalculatorPage', () => {
  test('should display 0 when the calculator is opened', () => {
    const { getByTestId } = render(<CalculatorPage />);
    const result = getByTestId('result');
    expect(result.textContent).toBe('0');
  });

  test('should display 1 when the 1 button is clicked', () => {
    const { getByRole, getByTestId } = render(<CalculatorPage />);
    fireEvent.click(getByRole('button', { name: '1' }));
    const result = getByTestId('result');
    expect(result.textContent).toBe('1');
  });

  test('should display 3 if we press 1 + 2 =', () => {
    const { getByRole, getByTestId } = render(<CalculatorPage />);
    fireEvent.click(getByRole('button', { name: '1' }));
    fireEvent.click(getByRole('button', { name: '+' }));
    fireEvent.click(getByRole('button', { name: '2' }));
    fireEvent.click(getByRole('button', { name: '=' }));
    const result = getByTestId('result');
    expect(result.textContent).toBe('3');
  });

  // <tbd> please add more test cases
});

