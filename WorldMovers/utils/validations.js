const required = (propertyType) => {
  return (input) =>
    (input && input.length > 0) || `${propertyType} is required.`;
};

const minLength = (propertyType, minLength) => {
  return (input) =>
    (input && input.length >= minLength) ||
    `${propertyType} must be at least ${minLength} characters.`;
};

const inputRange = (propertyType, minLength, maxLength) => {
  return (input) =>
    (input && input.length >= minLength && input.length <= maxLength) ||
    `${propertyType} must contain ${minLength}-${maxLength} characters.`;
};

const emailFormat = () => {
  const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
  return (input) =>
    (input && regex.test(input)) || "Please enter a valid email address.";
};

export default {
  required,
  minLength,
  inputRange,
  emailFormat,
};
