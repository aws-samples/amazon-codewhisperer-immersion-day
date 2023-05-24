from unittest import TestCase

# Function to sum two numbers
def sum(x, y):
    return x + y

class TestSum(TestCase):
    # test the sum method with integers
    def test_sum_integers(self):
        self.assertEqual(sum(1, 2), 3)
